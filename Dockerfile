# Stage 1: Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the .csproj files first to leverage Docker layer caching.
# Paths are relative to the build context (solution root).
# Corrected the COPY syntax and destination paths.
COPY BDD.Playwright.Core/BDD.Playwright.Core.Automation.csproj BDD.Playwright.Core/
COPY BDD.Playwright.Duckcreek/BDD.Playwright.Duckcreek.Automation.csproj BDD.Playwright.Duckcreek/
COPY BDD.Playwright.Guidewire/BDD.Playwright.Guidewire.Automation.csproj BDD.Playwright.Guidewire/
COPY BDD.Playwright.Test/BDD.Playwright.EndToEndTesting.csproj BDD.Playwright.Test/
# If BDD.Playwright.POM exists and is a dependency, add its .csproj copy here:
# COPY BDD.Playwright.POM/BDD.Playwright.POM.csproj BDD.Playwright.POM/

# Restore dependencies for the main test project.
# Using the correct path inside the container.
RUN dotnet restore BDD.Playwright.Test/BDD.Playwright.EndToEndTesting.csproj

# Copy the rest of the source code from the context into the image
COPY . .

# Set the working directory to the test project folder before building
WORKDIR "/src/BDD.Playwright.Test"

# Build the correct test project. Output to /app/build.
# --no-restore is used because we already restored dependencies.
RUN dotnet build BDD.Playwright.EndToEndTesting.csproj -c Release -o /app/build --no-restore

# Stage 2: Publish the application (creates a leaner set of artifacts)
FROM build AS publish
# Publish the correct test project.
# --no-build and --no-restore are used as build and restore are done.
RUN dotnet publish BDD.Playwright.EndToEndTesting.csproj -c Release -o /app/publish
# Stage 3: Create the final runtime image using the Playwright base image
FROM mcr.microsoft.com/playwright/dotnet:v1.51.0-jammy AS final
WORKDIR /app

# Copy the published output from the 'publish' stage
COPY --from=publish /app/publish .

# Set environment variables
ENV DISPLAY=:99
# Default Scenario_Tag if not provided externally
ENV Scenario_Tag=${Scenario_Tag:-"dcpolicy"}

# Entry point: Start Xvfb (virtual display) and run the tests
# Targets the correct test DLL based on the published project.
CMD Xvfb :99 -screen 0 1280x1024x24 -ac & \
    dotnet test --filter "Category=${Scenario_Tag}" BDD.Playwright.EndToEndTesting.dll


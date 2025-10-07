FROM mcr.microsoft.com/playwright/dotnet:v1.50.0-jammy AS base

# Set the working directory
WORKDIR /src

# Build stage
FROM base AS build
COPY ["BDD.Playwright.POM.csproj", "."]
RUN dotnet restore "./BDD.Playwright.POM.csproj"
COPY . .
RUN dotnet build "./BDD.Playwright.POM.csproj" -c Release -o /app/build

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/build .

# Set environment variables
ENV DISPLAY=:99
ENV Scenario_Tag=${Scenario_Tag:-"dcpolicy"}

# Run tests using Playwright
CMD Xvfb :99 -screen 0 1280x1024x24 -ac & \
    dotnet test --filter "Category=${Scenario_Tag}" "BDD.Playwright.POM.dll"
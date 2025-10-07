namespace BDD.Playwright.Core.Enums
{
    /// <summary>
    /// Specifies the type of validation to be performed on a form or PDF document.
    /// </summary>
    public enum FormValidationType
    {
        /// <summary>
        /// Pixel-to-Pixel validation, comparing the visual output of two documents.
        /// </summary>
        P2P,

        /// <summary>
        /// Text Style validation, comparing font styles, sizes, and other text attributes.
        /// </summary>

        TS,

        /// <summary>
        /// Content validation, comparing the textual content of two documents.
        /// </summary>
        CT,

        /// <summary>
        /// Performs all available validations (Pixel, Text Style, and Content).
        /// </summary>
        ALL,

        /// <summary>
        /// Ignore Dynamic Content validation, which skips areas that are expected to change.
        /// </summary>
        IDC,

        /// <summary>
        /// Validate Dynamic Content, which specifically checks areas that are expected to change against a data source.
        /// </summary>
        VDC,
    }
}

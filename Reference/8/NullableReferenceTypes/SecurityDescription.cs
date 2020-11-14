namespace _8.NullableReferenceTypes
{
    public class SecurityDescription
    {
        private string _shortDescription;
        private string? _detailedDescription;

        public SecurityDescription() // Warning! short description not initialized.
        {
        }

        public SecurityDescription(string securityShortDescription)
        {
            _shortDescription = securityShortDescription;
        }

        public void SetDescriptions(string securityShortDescription, string? details = null)
        {
            _shortDescription = securityShortDescription;
            _detailedDescription = details;
        }

        public string GetDescription()
        {
            if (_detailedDescription.Length == 0) // Warning! dereference possible null
            {
                return _shortDescription;
            }

            return $"{_shortDescription}\n, " +
                   $"{_detailedDescription}";
        }

        public string FullDescrption()
        {
            if (_detailedDescription == null)
            {
                return _shortDescription;
            }

            if (_detailedDescription.Length > 0)
            {
                return $"{_shortDescription}\n, " +
                       $"{_detailedDescription}";
            }

            return _shortDescription;
        }
    }
}

namespace Motto.MR.Shared.Enum
{
    public enum MotorcycleLicenseCategory
    {
        A,   // Motocicletas e similares
        AB,  // Motocicletas + automóveis leves
        AC,  // Motocicletas + caminhões
        AD,  // Motocicletas + ônibus/micro-ônibus
    }

    public static class LicenseCategory
    {
        public static bool Validate(string categoryInput)
        {
            var validCategories = System.Enum.GetNames(typeof(MotorcycleLicenseCategory));

            if (validCategories.Contains(categoryInput))
            {
                return true;
            }

            return false;
        }
    }
}

namespace BookStore.Client.Utils
{
    public static class Msg
    {
        public const string ErrParams = "Failed. Invalid parameters.";
        public const string ErrLess = "Failed. Not enough parameters.";
        public const string ErrNoID = "Failed. The entry wasn`t found.";
        public const string ErrExist = "Failed. Entry already exist.";
        public const string ErrProp = "Failed. Invalid property.";
        public const string ErrCopy = "Failed. No copies left.";

        public const string Delete = "The entry was deleted successfully.";
        public const string Create = "The entry was created successfully.";
        public const string Change = "The entry was changed successfully.";

        public const string ErrFactory = "Factory was not provided.";
        public const string ErrContext = "Context was not provided.";
    }
}

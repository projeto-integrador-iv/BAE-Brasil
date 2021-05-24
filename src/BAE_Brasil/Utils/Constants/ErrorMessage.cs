using BAE_Brasil.Models;

namespace BAE_Brasil.Utils.Constants
{
    public static class ErrorMessage
    {
        public const string GenericError = "One or more errors occurred";
        public const string EmailExists = "Email já cadastrado";
        public const string Required = "Campo obrigatório";
        public const string MinLength3 = "Deve possuir ao menos 3 caracteres";
        public const string MinLength2 = "Deve possuir ao menos 2 caracteres";
        public const string MinLength1 = "Deve possuir ao menos 1 caractere";
        public const string Length2 = "Deve possuir 2 caracteres";
        public const string Length8 = "Deve possuir 8 caracteres";
        public const string OnlyDigits = "Use apenas dígitos";
        public const string MinLength8 = "Deve possuir ao menos 8 caracteres";
        public const string EmailFormat = "Formato de email incorreto";
        public const string IncorrectField = "Incorrect username or password";
        public const string PasswordsMustMatch = "As senhas devem ser iguais";
        public const string UserNotFound = "User not found";
    }
}
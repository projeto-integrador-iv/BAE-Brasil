using System;
using System.ComponentModel.DataAnnotations;
using BAE_Brasil.Utils.Constants;
using BAE_Brasil.Utils.Enums;

namespace BAE_Brasil.Models.ViewModels
{
    public class CreateProfileViewModel
    {
        #region UserType
        public UserType UserType { get; set; }
        #endregion
        
        #region UserProfile
        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string FullName { get; set; }
        
        [Required(ErrorMessage = ErrorMessage.Required)]
        public DateTime BirthDate { get; set; }
        #endregion

        #region Document
        [Required(ErrorMessage = ErrorMessage.Required)]
        public DocumentType DocumentType { get; set; }

        [MinLength(3, ErrorMessage = ErrorMessage.MinLength3)]
        public string DocDescription { get; set; }
        #endregion

        #region Contato.Telefone
        [RegularExpression("^[0-9]+$", ErrorMessage = ErrorMessage.OnlyDigits)]
        [StringLength(2, MinimumLength = 2, ErrorMessage = ErrorMessage.Length2)]
        public string TelStateCode { get; set; }
        
        [RegularExpression("^[0-9]+$", ErrorMessage = ErrorMessage.OnlyDigits)]
        [StringLength(9, MinimumLength = 8, ErrorMessage = ErrorMessage.Length8)]
        public string TelNumber { get; set; }
        
        public const ContactType ContactTypeTelephone = ContactType.Telefone;
        #endregion
        
        #region Contato.Celular
        [RegularExpression("^[0-9]+$", ErrorMessage = ErrorMessage.OnlyDigits)]
        [StringLength(2, MinimumLength = 2, ErrorMessage = ErrorMessage.Length2)]
        public string CellStateCode { get; set; }
        
        [RegularExpression("^[0-9]+$", ErrorMessage = ErrorMessage.OnlyDigits)]
        [StringLength(9, MinimumLength = 8, ErrorMessage = ErrorMessage.Length8)]
        public string CellNumber { get; set; }
        
        public const ContactType ContactTypeCellPhone = ContactType.Celular;
        #endregion
    }
}
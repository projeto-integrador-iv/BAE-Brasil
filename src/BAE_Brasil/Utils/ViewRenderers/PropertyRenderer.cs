using System;
using BAE_Brasil.Identity.Utils.Enums;

namespace BAE_Brasil.Identity.Utils.ViewRenderers
{
    public class PropertyRenderer
    {
        private UserType _userType;

        public PropertyRenderer(UserType userType)
        {
            _userType = userType;
        }
        
        public string ByUserType(string seCandidato, string seEmpresa) 
            => _userType switch
            {
                UserType.Candidato => seCandidato,
                UserType.Empregador => seEmpresa,
                _ => throw new ArgumentNullException(paramName: nameof(_userType))
            };
    }
}
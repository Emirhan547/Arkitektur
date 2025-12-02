using Arkitektur.WebUI.Base;

namespace Arkitektur.WebUI.Exceptions
{
    public class ApiValidationException(List<Error>errors):Exception("API tarafından validasyon hatası alındı")
    {
        public List<Error> Errors { get;  }= errors;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdInfoSupplierVehicle.API.ViewModels
{
    public class VehicleBaseModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Marca.")]
        [MinLength(3, ErrorMessage = "O nome deve ter um tamanho mínimo de 3 caracteres.")]
        public string Marca { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o modelo.")]
        [EmailAddress(ErrorMessage = "Informe um modelo válido.")]
        public string Modelo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a versão.")]
        public string Versao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o ano.")]
        public int Ano { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a Quilometragem.")]
        public int Quilometragem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(AllowEmptyStrings = true, ErrorMessage = "Informe uma Observação.")]
        public string Observacao { get; set; }
    }
}

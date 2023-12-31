﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ProvaTecnicaSetis.Models
{
    [XmlRoot("ADM_UsuarioXPerfil")]
    public class ADM_UsuarioXPerfil
    {
        [XmlElement("USP_USU_Id")]
        public short USP_USU_Id { get; set; }

        [XmlElement("USP_PER_Id")]
        public short USP_PER_Id { get; set; }

        [XmlIgnore]
        [ForeignKey("USP_USU_Id")]
        public virtual ADM_Usuario Usuario { get; set; }
        
        [XmlElement("ADM_Perfil")]
        [ForeignKey("USP_PER_Id")]
        public virtual ADM_Perfil Perfil { get; set; }
    }
}

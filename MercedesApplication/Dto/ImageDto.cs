using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;


namespace Application.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}

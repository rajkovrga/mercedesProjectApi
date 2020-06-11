using MercedesApplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercedesApplication.Commands
{
    public interface IUploadProductPhotoCommand : ICommand<ImageDto>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using MercedesApplication;
using MercedesApplication.Commands;
using MercedesApplication.Dto;

namespace MercedesImplementation.Commands
{
    public class CreateProductCommand : ICreateProductCommand
    {
        public int Id => 1;

        public string Name => "Create product";

        public void Execute(ProductDto dto)
        {
            
        }
    }
}


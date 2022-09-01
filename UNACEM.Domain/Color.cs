using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UNACEM.Domain.Interfaces;

namespace UNACEM.Domain
{
    public class Color
    {
        public int Id { get; set; }
        public int Hex { get; set; }

    }
}

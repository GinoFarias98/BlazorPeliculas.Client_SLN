﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeliculas.Shared.Entidades
{
    public class Actor
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;
        public string? Biografia { get; set; }
        public string? Foto { get; set; }
        public DateTime? FechaNaciomiento { get; set; }
        [NotMapped]
        public string? Personaje { get; set; }
        public List<PeliculaActor> PeliculasActor { get; set; } = new List<PeliculaActor>();


        public override bool Equals(object? obj)
        {
            if (obj is Actor a2)
            {
                return Id == a2.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

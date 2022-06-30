using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Series.src
{
    public class SerieClass : EntitieBase
    {
        // Atributos
        private GenreEnum Genre { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }

        private bool Deleted { get; set; }


        // Métodos
        public SerieClass(int Id, GenreEnum Genre, string Title, string Description, int Year)
        {
            this.Id = Id;
            this.Title = Title;
            this.Genre = Genre;
            this.Description = Description;
            this.Year = Year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string newSerie = "";
            newSerie += "Title: " + this.Title + Environment.NewLine;
            newSerie += "Genre: " + this.Genre + Environment.NewLine;
            newSerie += "Description: " + this.Description + Environment.NewLine;
            newSerie += "Year: " + this.Year + Environment.NewLine;
            newSerie += "Deleted: " + this.Deleted;
            return newSerie;
        }


        // Encapsulamento
        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnDeleted()
        {
            return this.Deleted;
        }

        public void Remove()
        {
            this.Deleted = true;
        }

    }
}
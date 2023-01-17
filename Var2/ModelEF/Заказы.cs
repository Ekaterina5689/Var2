namespace Var2.ModelEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Заказы
    {
        [Key]
        public int IDЗаказа { get; set; }

        public int IDКниги { get; set; }

        public int Количество { get; set; }

        public decimal Стоимость { get; set; }

        [Required]
        [StringLength(150)]
        public string Сотрудник { get; set; }

        [Column(TypeName = "date")]
        public DateTime ДатаФормирования { get; set; }

        [Column(TypeName = "date")]
        public DateTime ДатаДоставки { get; set; }

        public virtual Книги Книги { get; set; }
    }
}

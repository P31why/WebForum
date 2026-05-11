using System;
using System.Collections.Generic;
using System.Text;

namespace WebForum.Infrastructure
{
    public interface IId<Tkey>
    {
        [System.ComponentModel.DataAnnotations.Key]
        Tkey Id { get; set; }
    }
}

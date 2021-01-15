using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
namespace TrelloA.tasks_management
{
        [Table(Name ="Tasks")]
        public class Task
        {
            [Column(IsPrimaryKey =true,IsDbGenerated =true)]
            public int Id { get; set; }
            [Column(Name ="Title")]
            public string Title { get; set; }
            [Column(Name ="Definition")]
            public string Description { get; set; }
            [Column(Name ="StatusId")]
            public int StatusId { get; set; }
          [Column(Name ="CreatorUserId",CanBeNull =false)]
           public int CreatorUserId { get; set; }
        }
}
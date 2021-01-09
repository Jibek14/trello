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
            [Column(Name ="UserInsertedTime",CanBeNull =true)]
            public DateTime UserInsertedTime { get; set; }
            [Column(Name = "UserDeletedTime", CanBeNull = true)]
            public DateTime UserDeletedTime { get; set; }
            [Column(Name ="MarkerId")]
            public int MarkerId { get; set; }
            [Column(Name ="StatusId")]
            public int StatusId { get; set; }
            [Column(Name ="UserId")]
            public int UserId { get; set; }
        }
    }
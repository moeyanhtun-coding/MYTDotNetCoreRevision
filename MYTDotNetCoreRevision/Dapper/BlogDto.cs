﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MYTDotNetCoreRevision.Dapper
{
        [Table("Tbl_BlogDotNetCore")]
        public class BlogDto
        {
            [Key]
            public int BlogId { get; set; }
            public string? BlogTitle { get; set; }
            public string? BlogAuthor { get; set; }
            public string? BlogContent { get; set; }

        }
 }


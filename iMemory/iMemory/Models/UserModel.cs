using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace iMemory.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "用户名不能为空！")]
        [Display(Name = "输入用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空！")]
        [DataType(DataType.Password)]
        [Display(Name = "输入密码")]
        public string Pwd { get; set; }
    }
}
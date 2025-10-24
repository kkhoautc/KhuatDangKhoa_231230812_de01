using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KhuatDangKhoa_231230812_de01.Models;

public partial class KdkComputer
{
    [Key]
    public int KdkComId { get; set; }

    [Required]
    [Display(Name = "Tên máy tính")]
    public string KdkComName { get; set; } = null!;

    [Range(100,5000,ErrorMessage ="Giá phải nằm trong 100 đến 5000")]
    [Display(Name = "Giá")]
    public decimal? KdkComPrice { get; set; }

    [RegularExpression(@".*\.(jpg|png|gif|tiff)$",ErrorMessage ="CHỉ được nhập file ảnh jpg,png,gif,tiff")]
    [Display(Name = "Ảnh Minh họa")]
    public string? KdkComImage { get; set; }

    [Display(Name= "Tình trạng")]
    public bool? KdkComStatus { get; set; }
}

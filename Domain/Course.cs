
namespace MinimalAPI.Domain;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("courseInfo")]
public class Course
{
    [Key]
    public int courseID {get;set;}
    public string courseName {get;set;}
    public int courseType {get;set;}
    [ForeignKey("courseType")]
    public CourseType CourseTypeInfo {get;set;}
    
}
using System.Collections.Generic;

namespace Template.Models
{
  public class BabyTemplate
  {
    public int BabyTemplateId { get; set; }
    public string Description { get; set; }
    public int DaddyId { get; set; }
    public Daddy Daddy { get; set; }
  }
}
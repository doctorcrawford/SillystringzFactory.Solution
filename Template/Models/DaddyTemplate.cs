using System.Collections.Generic;

namespace Template.Models
{
  public class DaddyTemplate
  {
    public int DaddyTemplateId { get; set; }
    public string Name { get; set; }
    public List<BabyTemplate> BabyTemplates { get; set; }
  }
}
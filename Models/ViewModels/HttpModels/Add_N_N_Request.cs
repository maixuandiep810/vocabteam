using System.Collections.Generic;

namespace vocabteam.Models.ViewModels
{
    public interface Add_N_N_Request<TOne_N_Model> where TOne_N_Model : class
    {
        List<TOne_N_Model> List { get; set; }
    }

    public interface One_N_Model
    {
        int AModelId { get; set; }
        
        List<int> ListBModelId { get; set; }
    }
}
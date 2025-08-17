using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class TrainingEvaluationCore:BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string trainingProgramId;

        public string TrainingProgramId
        {
            get { return trainingProgramId; }
            set { trainingProgramId = value; }
        }
        private string evaluationRate;

        public string EvaluationRate
        {
            get { return evaluationRate; }
            set { evaluationRate = value; }
        }
        private string evaluation;

        public string Evaluation
        {
            get { return evaluation; }
            set { evaluation = value; }
        }      

        private string evailuationDate;

        public string EvailuationDate 
        {
            get { return evailuationDate; }
            set { evailuationDate = value; }
        }
    }
}

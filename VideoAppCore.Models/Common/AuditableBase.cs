namespace VideoAppCore.Models.Common
{
    public class AuditableBase
    {
        /// <summary>
        /// 등록일
        /// </summary>
        //public DateTimeOffset Created { get; set; }
        public DateTime Created { get; set; }

        /// <summary>
        /// 등록자
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 수정자
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 수정일
        /// </summary>
        public DateTime? Modified { get; set; }
    }
}

namespace CiklumTasks.Common
{
    public class ApiResult
    {
        #region Properties
        public ApiResultType ResultType { get; set; } = ApiResultType.UNKNOWN;
        public ApiNextAction ResultNextAction { get; set; } = ApiNextAction.UNKNOWN;
        public string ResultInfo { get; set; }
        public object ObjResult { get; set; } = null;
        #endregion

        #region Constructors
        public ApiResult(ApiResultType resultType)
        {
            ResultType = resultType;
        }

        /// <summary>
        /// Constructor where a result type and an object are instantiated
        /// </summary>
        /// </summary>
        public ApiResult(ApiResultType resultType, object obj)
        {
            ResultType = resultType;
            ObjResult = obj;
        }

        /// <summary>
        /// Constructor where a result type and a string are instantiated
        /// </summary>
        public ApiResult(ApiResultType resultType, string resultInfo)
        {
            ResultType = resultType;
            ResultInfo = resultInfo;
        }

        /// <summary>
        /// Constructor where a result type, a string and an object are instantiated
        /// </summary>
        public ApiResult(ApiResultType resultType, string resultInfo, object obj)
        {
            ResultType = resultType;
            ResultInfo = resultInfo;
            ObjResult = obj;
        }
        #endregion

        #region Enum
        public enum ApiResultType
        {
            UNKNOWN,
            OK,
            ERROR,
            ERROR_PERSON_NOT_CREATED,
        }
        #endregion

        public enum ApiNextAction
        {
            UNKNOWN
        }
    }
}

namespace Layer.Domain.Resources
{
    public static class AppResourceKey
    {
        // Business logic error
        public const string ErrorIdNotExisted = "ERROR_ID_NOT_EXISTED";
        public const string ErrorIdExisted = "ERROR_ID_EXISTED";
        public const string ErrorEmailExisted = "ERROR_EMAIL_EXISTED";
        public const string ErrorCurrentPasswordInvalid = "ERROR_CURRENT_PASSWORD_INVALID";
        public const string ErrorEmailNotExistedOrConfirmed = "ERROR_EMAIL_NOT_EXISTED_OR_CONFIRMED";
        public const string ErrorEmailNotExisted = "ERROR_EMAIL_NOT_EXISTED";
        public const string ErrorSendResetPasswordMailFailed = "ERROR_SEND_RESET_PASSWORD_MAIL_FAILED";
        public const string ErrorSendConfirmationMailFailed = "ERROR_SEND_CONFIRMATION_MAIL_FAILED";
        public const string ErrorEmailNotConfirmed = "ERROR_EMAIL_NOT_CONFIRMED";
        public const string ErrorInvalidUserNameOrPassword = "ERROR_INVALID_USER_NAME_OR_PASSWORD";
        public const string ErrorLanguageSkillExisted = "ERROR_LANGUAGE_SKILL_EXISTED";
        public const string ErrorSkillExisted = "ERROR_SKILL_EXISTED";
        public const string ErrorApplicantIdNotExisted = "ERROR_APPLICANT_ID_NOT_EXISTED";
        public const string ErrorJobIdNotExisted = "ERROR_JOB_ID_NOT_EXISTED";
        public const string ErrorApplicationIdNotExisted = "ERROR_APPLICATION_ID_NOT_EXISTED";
        public const string ErrorUserNameNotExisted = "ERROR_USER_NAME_NOT_EXISTED";
        public const string ErrorUnexpected = "ERROR_UNEXPECTED";
        public const string ErrorApplicationIsSubmitted = "ERROR_APPLICATION_IS_SUBMITTED";

        // Validation Error
        public const string ErrorFieldRequired = "ERROR_FIELD_REQUIRED";
        public const string ErrorMinLength = "ERROR_MIN_LENGTH";
        public const string ErrorPasswordConfirmationNotMatch = "ERROR_PASSWORD_CONFIRMATION_NOT_MATCH";
        public const string ErrorDateTimeRangeInvalidErrorKey = "ERROR_DATE_TIME_RANGE_INVALID";
        public const string ErrorMonthYearRangeInvalid = "ERROR_MONTH_YEAR_RANGE_INVALID";
        public const string ErrorMonthYearRangeNotInFuture = "ERROR_MONTH_YEAR_RANGE_NOT_IN_FUTURE";
        public const string ErrorMonthYearRangeFromMonthWithoutYear = "ERROR_MONTH_YEAR_RANGE_FROM_MONTH_WITHOUT_YEAR";
        public const string ErrorMonthYearRangeToMonthWithoutYear = "ERROR_MONTH_YEAR_RANGE_TO_MONTH_WITHOUT_YEAR";
        public const string ErrorInvalidCharacterRange = "ERROR_INVALID_CHARACTER_RANGE";
    }
}

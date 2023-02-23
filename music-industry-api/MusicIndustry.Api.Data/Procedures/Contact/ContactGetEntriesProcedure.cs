using MusicIndustry.Api.Core.Helpers;
using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Core.Models.Contact;
using MusicIndustry.Api.Data.Models;

namespace MusicIndustry.Api.Data.Procedures;

[Procedure]
public class ContactGetEntriesProcedure
{
    public static string Name => "procContactGetEntries";
    public static int Version => 3;
    public static string Text => $@"
/* version={Version} */
CREATE PROCEDURE [{Name}]
    {ProcedureParams.AllowDirtyRead} BIT,
    {ProcedureParams.Offset} INT = 0,
    {ProcedureParams.Limit} INT = 1,
    {ProcedureParams.Id} INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF {ProcedureParams.AllowDirtyRead} = 1
    BEGIN
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    END

    SELECT
    m.[{nameof(Contact.Id)}] AS [{nameof(ContactReportModel.Id)}],
    m.[{nameof(Contact.FirstName)}] AS [{nameof(ContactReportModel.FirstName)}],
    m.[{nameof(Contact.LastName)}] AS [{nameof(ContactReportModel.LastName)}],
    m.[{nameof(Contact.Title)}] AS [{nameof(ContactReportModel.Title)}],
    m.[{nameof(Contact.Company)}] AS [{nameof(ContactReportModel.Company)}],
    m.[{nameof(Contact.Email)}] AS [{nameof(ContactReportModel.Email)}],
    m.[{nameof(Contact.PhoneCell)}] AS [{nameof(ContactReportModel.PhoneCell)}],
    m.[{nameof(Contact.PhoneBusiness)}] AS [{nameof(ContactReportModel.PhoneBusiness)}],
    m.[{nameof(Contact.Fax)}] AS [{nameof(ContactReportModel.Fax)}],
    m.[{nameof(Contact.AddressLine1)}] AS [{nameof(ContactReportModel.AddressLine1)}],
    m.[{nameof(Contact.AddressLine2)}] AS [{nameof(ContactReportModel.AddressLine2)}],
    m.[{nameof(Contact.City)}] AS [{nameof(ContactReportModel.City)}],
    m.[{nameof(Contact.State)}] AS [{nameof(ContactReportModel.State)}],
    m.[{nameof(Contact.Zip)}] AS [{nameof(ContactReportModel.Zip)}],
    m.[{nameof(Contact.IsActive)}] AS [{nameof(ContactReportModel.IsActive)}],
    m.[{nameof(Contact.DateCreated)}] AS [{nameof(ContactReportModel.DateCreated)}],
    m.[{nameof(Contact.DateModified)}] AS [{nameof(ContactReportModel.DateModified)}]
    FROM [{ContactExtension.TABLE_NAME}] m
    WHERE {ProcedureParams.Id} IS NULL OR m.[{nameof(Contact.Id)}] = {ProcedureParams.Id}
    ORDER BY m.[{nameof(Contact.Id)}]
    OFFSET {ProcedureParams.Offset} ROWS FETCH NEXT {ProcedureParams.Limit} ROWS ONLY
    
    IF {ProcedureParams.Id} IS NULL
    BEGIN
        SELECT COUNT(*)
        FROM [{ContactExtension.TABLE_NAME}] m
    END
END";
}

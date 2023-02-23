using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Data.Models;

namespace MusicIndustry.Api.Data.Procedures;

[Procedure]
public static class PlatformContactsGetEntriesProcedure
{
    public static string Name => "procPlatformContactsGetEntries";
    public static int Version => 5;
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
    p.[{nameof(PlatformContacts.Id)}] AS [{nameof(PlatformContactsReportModel.Id)}],
    p.[{nameof(PlatformContacts.PlatformId)}] AS [{nameof(PlatformContactsReportModel.PlatformId)}],
    p.[{nameof(PlatformContacts.ContactId)}] AS [{nameof(PlatformContactsReportModel.ContactId)}]
    FROM [{PlatformContactExtension.TABLE_NAME}] p
    WHERE {ProcedureParams.Id} IS NULL OR p.[{nameof(PlatformContacts.Id)}] = {ProcedureParams.Id}
    ORDER BY p.[{nameof(Platform.Id)}]
    OFFSET {ProcedureParams.Offset} ROWS FETCH NEXT {ProcedureParams.Limit} ROWS ONLY
    
    IF {ProcedureParams.Id} IS NULL
    BEGIN
        SELECT COUNT(*)
        FROM [{PlatformContactExtension.TABLE_NAME}] p
    END
END";
}
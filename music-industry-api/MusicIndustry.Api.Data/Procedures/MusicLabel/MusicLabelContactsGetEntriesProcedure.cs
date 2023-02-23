using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Data.Models;

namespace MusicIndustry.Api.Data.Procedures;

[Procedure]
public static class MusicLabelContactsGetEntriesProcedure
{
    public static string Name => "procMusicLabelContactsGetEntries";
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
    ml.[{nameof(MusicLabelContacts.Id)}] AS [{nameof(MusicLabelContactsReportModel.Id)}],
    ml.[{nameof(MusicLabelContacts.ContactId)}] AS [{nameof(MusicLabelContactsReportModel.ContactId)}],
    ml.[{nameof(MusicLabelContacts.MusicLabelId)}] AS [{nameof(MusicLabelContactsReportModel.MusicLabelId)}]
    FROM [{MusicLabelContactExtension.TABLE_NAME}] ml
    WHERE {ProcedureParams.Id} IS NULL OR ml.[{nameof(MusicLabelContacts.ContactId)}] = {ProcedureParams.Id}
    ORDER BY ml.[{nameof(MusicLabelContacts.Id)}]
    OFFSET {ProcedureParams.Offset} ROWS FETCH NEXT {ProcedureParams.Limit} ROWS ONLY
    
    IF {ProcedureParams.Id} IS NULL
    BEGIN
        SELECT COUNT(*)
        FROM [{MusicLabelContactExtension.TABLE_NAME}] p
    END
END";
}
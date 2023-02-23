using MusicIndustry.Api.Core.Models;
using MusicIndustry.Api.Data.Models;

namespace MusicIndustry.Api.Data.Procedures;

[Procedure]
public class MusicianContactsGetEntriesProcedure
{
    public static string Name => "procMusicianContactsGetEntries";
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
    ml.[{nameof(MusicianContacts.Id)}] AS [{nameof(MusicianContactsReportModel.Id)}],
    ml.[{nameof(MusicianContacts.ContactId)}] AS [{nameof(MusicianContactsReportModel.ContactId)}],
    ml.[{nameof(MusicianContacts.MusicianId)}] AS [{nameof(MusicianContactsReportModel.MusicianId)}]
    FROM [{MusicianContactsExtension.TABLE_NAME}] ml
    WHERE {ProcedureParams.Id} IS NULL OR ml.[{nameof(MusicianContacts.ContactId)}] = {ProcedureParams.Id}
    ORDER BY ml.[{nameof(MusicianContacts.Id)}]
    OFFSET {ProcedureParams.Offset} ROWS FETCH NEXT {ProcedureParams.Limit} ROWS ONLY
    
    IF {ProcedureParams.Id} IS NULL
    BEGIN
        SELECT COUNT(*)
        FROM [{MusicianContactsExtension.TABLE_NAME}] p
    END
END";
}

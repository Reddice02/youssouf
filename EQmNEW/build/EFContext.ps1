Set-Location ../src/Activ.EQM/Activ.EQM.DataAccess
dotnet ef dbcontext scaffold "Server=.;Database=EQM;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
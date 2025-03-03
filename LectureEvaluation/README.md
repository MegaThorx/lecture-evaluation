# LectureEvaluation

Create migration
```
dotnet ef migrations add -p LectureEvaluation -o Infrastructure/Migrations AddLecturesAndEvaluations
```

```
Add-Migration -Name AddLecturesAndEvaluations -Project LectureEvaluation -OutputDir Infrastructure/Migrations
```
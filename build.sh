#! /bin/sh

dotnet build PracticeWebApp

dotnet build PracticeWebApp.Tests

dotnet test  PracticeWebApp.Tests

dotnet build PracticeWebApp.FuncTest

dotnet test  PracticeWebApp.FuncTest
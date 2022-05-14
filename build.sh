#! /bin/sh

dotnet build PracticeWebApp
dotnet build PracticeWebApp.Tests
dotnet test  PracticeWebApp.Tests


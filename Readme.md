## Setup

### Entra ID

#### Using Managed Identity

Give MI Contributor role to Video Indexer

#### Using registered application

1. Register an application
1. If runninng locally, set AZURE_TENANT_ID, _CLIENT_ID, _CLIENT_SECRET environment variables
1. Assign this service principal as Contributor to VI

## Examples

### Get Video Index

```
https://api.videoindexer.ai/eastus/Accounts/0dbb2365-1989-4a0b-9191-54cfafcea2b9/Videos/3jq0p0vhsl/Index?includedInsights=Faces%2CObservedPeople&includeSummarizedInsights=false&accessToken=eyJhbGciOiJSUz...
```

```json
{"partition":"partition","description":"video_description","privacyMode":"Private","state":"Processed","accountId":"0dbb2365-1989-4a0b-9191-54cfafcea2b9","id":"3jq0p0vhsl","name":"myVideo","userName":" ","created":"2024-10-29T03:13:51.72+00:00","isOwned":true,"isEditable":true,"isBase":true,"durationInSeconds":11,"duration":"0:00:11.812","summarizedInsights":null,"videos":[{"accountId":"0dbb2365-1989-4a0b-9191-54cfafcea2b9","id":"3jq0p0vhsl","state":"Processed","moderationState":"OK","reviewState":"None","privacyMode":"Private","processingProgress":"100%","failureMessage":"","externalId":null,"externalUrl":null,"metadata":null,"insights":{"version":"1.0.0.0","duration":"0:00:11.812","sourceLanguage":"en-US","sourceLanguages":["en-US"],"language":"en-US","languages":["en-US"],"textualContentModeration":{"id":0,"bannedWordsCount":0,"bannedWordsRatio":0,"instances":[]},"statistics":{"correspondenceCount":0,"speakerTalkToListenRatio":{},"speakerLongestMonolog":{},"speakerNumberOfFragments":{},"speakerWordCount":{}}},"thumbnailId":"19a8328e-14ba-4cf9-ad6f-a5aefb1d7ace","width":1280,"height":720,"detectSourceLanguage":false,"languageAutoDetectMode":"None","sourceLanguage":"en-US","sourceLanguages":["en-US"],"language":"en-US","languages":["en-US"],"indexingPreset":"Default","streamingPreset":"Default","linguisticModelId":"00000000-0000-0000-0000-000000000000","personModelId":"00000000-0000-0000-0000-000000000000","logoGroupId":null,"isAdult":false,"excludedAIs":[],"isSearchable":true,"publishedUrl":"https://api.videoindexer.ai/internals/eastus/Accounts/0dbb2365-1989-4a0b-9191-54cfafcea2b9/Videos/3jq0p0vhsl/streaming-manifest/manifest.m3u8","publishedProxyUrl":null,"viewToken":"eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJWZXJzaW9uIjoiMi4wLjAuMCIsIktleVZlcnNpb24iOiI3ZmJkMDkxOGRmMWM0NGNjYTI3ZTA2NGQyYWZkYWViOSIsIkFjY291bnRJZCI6IjBkYmIyMzY1LTE5ODktNGEwYi05MTkxLTU0Y2ZhZmNlYTJiOSIsIkFjY291bnRUeXBlIjoiQ2xhc3NpYyIsIlZpZGVvSWQiOiIzanEwcDB2aHNsIiwiUGVybWlzc2lvbiI6IlJlc3RyaWN0ZWRWaWV3ZXIiLCJFeHRlcm5hbFVzZXJJZCI6IjM1QTA1QTFDMjQ1QzRBOTc5QTlDOTdCRkE1QTM4ODAxIiwiVXNlclR5cGUiOiJNaWNyb3NvZnRDb3JwQWFkIiwiSXNzdWVyTG9jYXRpb24iOiJlYXN0dXMiLCJuYmYiOjE3MzAyMTc3NjYsImV4cCI6MTczMDIyMTY2NiwiaXNzIjoiaHR0cHM6Ly9hcGkudmlkZW9pbmRleGVyLmFpLyIsImF1ZCI6Imh0dHBzOi8vYXBpLnZpZGVvaW5kZXhlci5haS8ifQ.Px_tVDRoKSYoLq7m-urFcQNFMiKRh44g83HWK08n8aITcFue2nz9G5VvZ2KNloRYmiumvOgZGcvFBecwYwzWjmgYkLxAguDcJjsEFNabEVi2k7x7wVET95-1FL6mRWR325Z8mgPDo4Hx2LF8Tfi42tvepuAegvk0rInhCQme1_xf77wAHKEvrbpZt_7LCCDWkkiWakCFsCpS5SJw-LzUSpSvv3gXD8HH8T6pHxVj_Pg8Fq2Mz1cMkMDcklNG97APRTEhEgr1ZHLu9b492XWPmeK_kKX78PRkMbvwKxHND_Om4G9gcd6M-uYE7CIx9GKKxyC9FITq433dSNQK-1TzQA"}],"videosRanges":[{"videoId":"3jq0p0vhsl","range":{"start":"0:00:00","end":"0:00:11.812"}}]}
```
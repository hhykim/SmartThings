# SmartThings

![C# WinForms](https://img.shields.io/badge/c%23_WinForms-239120?style=for-the-badge&logo=.net&logoColor=white)
![RestSharp](https://img.shields.io/badge/RestSharp-000065?style=for-the-badge)

![](screenshot.png?raw=true)

SmartThings API를 통해 공식 앱에서 지원하지 않는 에어컨 온도 조절을 구현한 프로그램입니다.

<br>

## 사용법

> [!IMPORTANT]
> SmartThings에 에어컨을 연결했던 삼성 계정을 사용해야 합니다.

1. [Personal Access Token](https://account.smartthings.com/tokens)을 발급받습니다.
2. 에어컨의 `deviceId`를 찾습니다.
```bash
curl -H "Authorization: Bearer YOUR_TOKEN" https://api.smartthings.com/v1/devices
```
3. `SmartThingsService.cs` 파일의 `Token`, `Url` 변수에 값을 채웁니다.

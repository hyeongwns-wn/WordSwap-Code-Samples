# WordSwap · Code Samples

개발 중인 Unity 프로젝트에서 사용한 실제 C# 소스 일부를 공개합니다.
UI 상태 전달, 이벤트 구독 수명 관리, 행동 비용 처리를 중심으로 코드의 책임 분리를 설명합니다.

## 먼저 볼 코드

| 순서 | 코드 | 확인할 내용 |
|---|---|---|
| 1 | [PlayerViewModel](Source/ViewModel/PlayerViewModel.cs) | 런타임 상태를 화면용 Observable로 전달 |
| 2 | [Observable](Source/Core/Observable.cs) | 값 변경 감지와 이벤트 알림 |
| 3 | [HealthBarView](Source/View/HealthBarView.cs) | 외부 상태 바인딩, HP 표시, 구독 해제 |
| 4 | [ViewModelBase](Source/ViewModel/ViewModelBase.cs) | 생성한 Observable의 정리 책임 관리 |
| 5 | [ActionCostService](Source/Core/Combat/ActionCostService.cs) | 비용 합산, 사용 조건 검사, 성공 시 차감 |

## 구조와 설계 의도

- [MVVM 지향 구조와 실제 HP 바 연결 흐름](Docs/MVVM.md)
- [행동 비용 처리와 실패 시 상태 보존](Docs/ActionCosts.md)

PlayerViewModel은 개별 자원과 스탯을 노출하는 코드입니다.
HealthBarView는 전투 ViewModel의 HP 튜플을 구독합니다.
두 화면 경로를 구분하여 MVVM 문서에 설명했습니다.

## 공개 범위와 실행 조건

Source 폴더의 C# 파일은 실제 프로젝트에서 발췌했습니다. 네임스페이스와 구현을 유지하며 줄바꿈만 정규화했습니다.
문서의 일부 짧은 코드는 비공개 파일에서 해당 구간만 가져온 것으로 표시했습니다.

이 저장소는 코드 열람용 발췌본입니다. RuntimePlayer, RuntimePlayerTurn 등 프로젝트 의존성의 전체 정의와 씬을 포함하지 않으므로 단독 빌드는 지원하지 않습니다.
UI 코드는 Unity UGUI와 TextMeshPro를 사용합니다.

게임 콘텐츠, 상세 규칙, 에셋과 프로젝트의 Git 이력은 공개 범위에 포함하지 않습니다.

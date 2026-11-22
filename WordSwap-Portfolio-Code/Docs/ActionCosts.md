# 행동 비용 처리

[ActionCostService.cs](../Source/Core/Combat/ActionCostService.cs)는 행동 예산과 추가 자원의 사용 조건을 확인하고 비용을 차감합니다.

## 해결하려는 문제

여러 자원을 순서대로 검사하면서 차감하면 뒤쪽 자원이 부족할 때 앞쪽 자원만 소모될 수 있습니다.
전체 비용을 먼저 합산하고 모든 조건이 충족된 경우 상태를 변경하도록 구성했습니다.

## 처리 순서

1. 상태와 비용 정의를 검증합니다.
2. 동일 자원의 여러 비용을 합산합니다.
3. 행동 예산과 HP, MP, Gold를 확인합니다.
4. 행동 예산 지불 성공 후 나머지 자원을 차감합니다.

CanPay는 사용 가능 여부 조회에 쓰고, TryPay는 호출 시점에 다시 검사합니다.
HP 비용은 지불 후 최소 1이 남도록 비교합니다.
합산에는 checked를 적용하여 정수 오버플로를 차감 전에 발견합니다.

## 데이터와 책임

[ActionCostData](../Source/Model/Data/ActionCostData.cs)는 행동 예산과 자원 비용 목록을 담습니다.
[ActionResourceCostData](../Source/Model/Data/ActionResourceCostData.cs)와 [ActionResourceType](../Source/Model/Enums/ActionResourceType.cs)은 추가 비용의 종류와 수량을 표현합니다.

이 코드는 UI 컴포넌트를 참조하지 않습니다.
현재 자원과 예산을 인자로 받아 비용 처리에 집중합니다.

## 범위

동일 스레드의 동기 실행을 전제로 합니다.
비용 지불 이후 다른 효과 처리에서 발생한 오류의 복구는 별도 책임입니다.
RuntimePlayer와 RuntimePlayerTurn의 전체 구현은 비공개이며, 본 저장소에는 원본 의존성 이름을 유지한 발췌본을 제공합니다.

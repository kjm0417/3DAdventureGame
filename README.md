# 3DAdventureGame
3d로 만드는 게임과제

###구현 내용
1. 기본 이동 및 점프
2. 체력바
3. 조사
4. 점프대
5. 아이템 데이터
6. 아이템 사용
7. 추가 UI
8. 3인칭
9. 다양한 아이템 구현
10. 레이저 트랩
11. 움직이는 플랫폼

##구현 하면서 설계 내용
1. 점프대와 레이저 트랩은 같은 trigger로 구현하고 구현 내용부분만 다르기 때문에 Interface로 구현 해보면 좋을 것 같아서 진행
2. 아이템구현할 때 스크립터블오브젝트로 데이터를 받아서 작성

##하다가 생긴 문제
1.Player 초기화 내용에서 모든 부분의 초기화를 Start로 해줘서 문제가 발생 - Awake로 플레이어를 가장먼저 초기화 해주는 코드로 교체
2. 점프의 구현을 다했는데 점프가 안됨 - 바닥 layerMask를 설정 안해줌
3. 레이저 트랩, 움직이는 플랫폼에서 플레이어에게 물리영향을 주지않아서 같이 움직이지 않음 - 해결 못함

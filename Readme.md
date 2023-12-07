# Cleaner 벽돌깨기 팀 프로젝트


</br>

## 팀원: 김국민(팀장), 임종운, 조형승, 송하겸, 이승철

> Unity로 개발한 벽돌깨기 게임 프로젝트 입니다.  
> 5인 팀 프로젝트이며, 고전게임를 현대식으로  재해석 및 개발한 내용입니다.  
> 소통과 협업을 위주로 개발하였고, 핵심 내용은 '충돌' 입니다.
> 개발 기간은 5일입니다.
> 구현된 내용은 다음과 같습니다.

</br>

## 주요 기능
* 누적 공부시간
* 배경 음악
* 보스 라운드, 보스 패턴
* 아이템 장착
* 시간별 보너스 스코어

* 게임 시작 화면
    * 옵션 플레이어 데이터 삭제 기능
    * 볼륨 조절
    * 난이도 별 게임 시작
    * 난이도 별 게임 해금 기능(점심, 저녁)
    * 상점이동

* 게임 진행 화면
    * 라운드 진입 1 - 1, 1 - 2, 보스라운드
    * 설정
        * 볼륨 조절
        * 다시하기
        * 메인으로



## 기능 세부 설명
* 게임 시작 / 게임 시작 화면  
    * 아침, 점심, 저녁 세 가지 난도별로 게임 구분  
    * 옵션에서 볼륨 조절 및 현재 데이터 삭제
    * 배경 음악
    
* 게임 진행(아침)  
    * 라운드 진행
    * 1-1, 1-2 벽돌 배치
    * 보스라운드 진입
    * 보스 일정 HP도달시 기믹(패턴) 생성
    * 게임 종료시 목숨이 없으면 보너스 스코어 못받음
    * 보스를 잡으면 시간에 따라 보너스 스코어 증정

* 게임 진행(점심)
    * 라운드 진행
    * 1-1, 1-2 벽돌 배치
    * 보스라운드 진입 
    * 보스 일정 HP도달시 기믹(패턴) 생성
    * 게임 종료시 목숨이 없으면 보너스 스코어 못받음
    * 보스를 잡으면 시간에 따라 보너스 스코어 증정  

* 게임 진행(저녁)
    * 보스라운드 진입
    * 게임 종료시 목숨이 없으면 보너스 스코어 못받음
    * 보스를 잡으면 고정 스코어 증정


##  기술 스택

![Unity](https://img.shields.io/badge/-Unity-%23000000?style=flat-square&logo=Unity)
![C#](https://img.shields.io/badge/-C%23-%7ED321?logo=Csharp&style=flat)

## 와이어 프레임

![WierFrame](https://github.com/gugmin/Cleaner/assets/149454489/5b1ebdab-28b7-47e3-be9b-8ab5ac93aa77)

## 시연 영상

[프로젝트 시연영상] https://www.youtube.com/watch?v=g-FI9eE4yck&list=PLCGNliqjPOIStkvGQXue8hCoxbcVQNPPD&index=3

## 구현한 기능


### 게임 시작 화면

![GameStartScene](https://github.com/gugmin/Cleaner/assets/149454489/13e2d710-f8e2-4d48-92af-a18812a592fa)

 __옵션__  
 <br/>
![alt](https://github.com/gugmin/Cleaner/assets/149454489/7860913b-d0bc-4cf8-a901-5e77606da006)

* 3가지 난이도로 나뉘어져 있으며 우측 상단에는 옵션버튼이 있음
* 좌측 상단에는 상점 버튼이 있음
* 플레이 초기 화면이기에 '점심, 저녁' 난이도는 잠금, '아침'만 활성화 

<br/>

__볼륨 조절__

* 볼륨 조절 가능함

![시작화면(볼륨조절)](https://github.com/gugmin/Cleaner/assets/149454489/0249dab6-ca32-45df-9584-c0ec0d348539)
<br>

__데이터 삭제__  

![Option](https://github.com/gugmin/Cleaner/assets/149454489/cb803584-2038-421d-b80c-410dab0bb9ea)

* 플레이어 데이터 초기화 가능  
* 버튼 클릭시 경고창 한번 더 나옴

<br>

__상점__  

![Shop](https://github.com/gugmin/Cleaner/assets/149454489/6716a6b3-ffb0-475c-9b19-bf41c7c75805)

* 누적 공부시간에 따른 아이템 해금

![Item_Sand](https://github.com/gugmin/Cleaner/assets/149454489/f9e87f1b-c863-48b4-a739-543f0d0a9a6e)

* 아이템 정보 창

![장착아이템정보창](https://github.com/gugmin/Cleaner/assets/149454489/50961d5f-121e-486c-9a25-9c0feae07835)

* 해금된 아이템 장착

![Item_Sand](https://github.com/gugmin/Cleaner/assets/149454489/3497eab1-9af2-4eee-b52c-e5f7c3065212)

* 2개 이상 장착시 뜨는 경고문

![상점화면(경고)](https://github.com/gugmin/Cleaner/assets/149454489/05264c53-429a-4438-8809-5d17e591be26)

<br>
### 게임 진행 공통 부분

__일시정지__  

![Pause](https://github.com/gugmin/Cleaner/assets/149454489/ee8b2f87-0474-4965-8e4d-79339878afbe)
* 일시정지시 시간 멈춤
* 계속진행, 다시하기, 홈으로가기 구현 

__일시정지볼륨조절__ 

![게임중일시정지볼륨조절](https://github.com/gugmin/Cleaner/assets/149454489/96303f24-e1a7-4c9f-ae4b-a9bae9e798af)

__시간 제한__  

![Pause](https://github.com/gugmin/Cleaner/assets/149454489/88b66e7a-c604-480f-a2c0-1f9ba0180b05)
* 시간 표시를 해준는 곳
* 별 갯수에 따라 보너스 스코어 증정 

<br/>  

__게임 종료시 판넬__  

![EndPanel](https://github.com/gugmin/Cleaner/assets/149454489/0af5e078-429b-457f-b8db-c40b90ad1114)

<br/>

* 난도별 최고점수 따로 기록
* 최고점수 및 이번판 점수 출력
* 비교 후 점수가 높으면 최고점수 갱신
* 메인으로, 다시하기 버튼 구현
 
 <br/>



### 게임 진행 화면

<br/>

__아침(Easy) 모드__

![EasyGame]

* 1 - 1라운드 5 X 5 / 2 으로 진행  

![brick1](https://github.com/gugmin/Cleaner/assets/149454489/105a2e04-7535-43f8-b9c0-7bc30c4f373c)

* 1 - 2라운드 5 X 5 으로 진행  

![brick1](https://github.com/gugmin/Cleaner/assets/149454489/2722ddf4-b101-4911-9a71-d7d17ac9e857)

* 1 - 3 보스

![아침Boss(클리어_전)](https://github.com/gugmin/Cleaner/assets/149454489/ffb89662-e493-4049-a839-29e662495e6d)

* 목숨을 다 잃을 시 엔드판넬 출력


<br/>

__Normal 해금__

![NormalUnlocked](https://github.com/gugmin/Cleaner/assets/149454489/83b1951f-2426-4723-9fb1-865db40a4fb0)
<br/>

__Normal 모드__  

![NormalGame]

* 1 - 1라운드 5 X 5 / 2 으로 진행 

![Normal](https://github.com/gugmin/Cleaner/assets/149454489/d4aabac1-de65-41d9-8f44-f535cc9756a7)

* 1 - 2라운드 5 X 5 으로 진행  

![점심2-2스테이지](https://github.com/gugmin/Cleaner/assets/149454489/53873dfe-4a06-4d43-b972-dcc08e674f80)

* 1 - 3 보스

![점심Boss(클리어전)](https://github.com/gugmin/Cleaner/assets/149454489/252d9d49-53f4-466e-ad34-fde6c285658d)

* 패턴

![점심BOSS(게임도중)](https://github.com/gugmin/Cleaner/assets/149454489/d12f7b0d-37de-4c9a-b962-8243d5348cb0)

* 목숨을 다 잃을 시 엔드판넬 출력


<br/>

__Hard 모드해금__  

![HardUnlocked](https://github.com/gugmin/Cleaner/assets/149454489/e52c8e76-51a9-4073-94d5-8b1b7fc67b3e)
<br/>   

__Hard 모드__  

![HardGame](https://github.com/gugmin/Cleaner/assets/149454489/a6c9bafa-5045-4066-b373-af067d62171b)

* 패턴

![3Boss패턴](https://github.com/gugmin/Cleaner/assets/149454489/98efaba6-2339-42c8-8a16-c58691458ed4)

* 보스를 잡을 시 퇴실 버튼 등장

![퇴실](https://github.com/gugmin/Cleaner/assets/149454489/9959c60f-aef5-4557-aa3c-34945f8e7576)

* 퇴실 확인

![퇴실완료](https://github.com/gugmin/Cleaner/assets/149454489/ea232eba-6dab-4898-a02e-7eb5f15fb226)

<br/>

## 프로젝트 시 일어난 문제와 해결  

### 프로젝트

__문제__:  충돌을 피하기 위해 Scene 복제하고 작업했음에도 불구하고 충돌 발생
 
문제가 발생한 상황 : 처음부터 Scene병합에 충돌이 있을것을 알고 일부러 복제를 하여 작업을 진행했는데도
결국 충돌이 발생했다.
문제 해결을 위해 노력한 것 : export package 를 활용해 충돌을 최소화

__결과__:  Scene끼리 병합에 문제없이 성공하고 작업을 진행할 수 있게되었다.



### GitHub  

__문제__:  default branch인 main에 파일을 올리는 것을 너무 미뤄두다가 한번에 올리는 작업을 시도했다.
그 결과 시간의 흐름에 알 수 없는 버그가 발생하고 다시 되돌릴려고 이것저것 만지다가 폭파해버렸다.
 

__증상__:  깃허브 이그노어를 생성 전으로 돌아가 버려서 생성파일이 26000개쯤 생겨버림

해결방안 : default branch를 최종단계 까지 진행된 branch로 바꿨음.

## 프로젝트 소감

___김국민___  

처음 해보는 팀장이지만   팀원들이 오히려 잘 이끌어줘서 아주 잘 마칠 수 있었던거 같습니다. 이번에 배운것들을 잊지 않고 더 발전할 수 있게 노력 하겠습니다!
<br/>

___임종운___  

  고전 게임인데도 고민해야 하는 부분이 생각보다 많았고 배울 점이 많았던 프로젝트였습니다.
<br/>

___조형승___  

아직 배워야할 것들이 많은 부족한 실력이지만 함께하는 조원들이 있어서 이번 과제를 무사히 마무리 할 수 있었습니다. 협업을 하면서 git 과 C#, Unity 에 조금씩 익숙해지는 성장이 있었고, 배움의 즐거움을 느낄 수 있어 감사하고 행복했습니다 !
<br/>

___송하겸___   

로직을 구현하는 과정에서 문제가 발생해도 팀원들과의 소통이 원활해서 금방 해결할 수 있었습니다. 많이 배웠습니다.
<br/>

___이승철___ 

제 부족한 실력으로 인해서 조원들의 도움을 받아 대부분의 문제를 해결할 수 있었고 협업의 어려움을 조금 알게 된 것 같습니다. 다음에는 팀의 더욱 도움이 되고…   [더보기]
<br/>

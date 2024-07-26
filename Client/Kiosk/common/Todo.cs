using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.common
{
    internal class TodoList
    {
        /*
            1. Client
                1-1. KioskPanel에서 페이징 event 구현(button1/◀, button2/▶)


            2. Server
                2-1. Client로부터 수신받은 DataTable을 주문목록창에 띄우기, 동적 UI 구현

                2-2. Clients To Server(N:1) 이지만 실제로 사용은 Client To Server(1:1)에 대한 Server 예외처리
                    2-2-1. 만약 Client To Server(1:1)에서 막혔을 경우 Clients To Server(N:1) 방안도 미리 생각해둘 것

                2-3. 주문 목록에 대한 CURD 구현
                    2-3-1. Delete 의 경우 UI에서 GroupBox를 Delete 하는 것 뿐만아니라, DB에서 삭제 후에 OrderNumber, ItemNumber를 초기화
                           물론, Sql Select 문을 통해 Max값을 찾아 넣기때문에 문제는 없겠지만 혹시 모르니 다시 한번 점검할 것

                2-4. Server에서 Order시에 Table에 바로 넣는 방안에서 Client와 동일하게 Temporary Table 방안으로 수정할 지 여부 토의할 것

                2-5. 결제 내역 UI 구현, 언제 어떤 메뉴를 얼마나 결제했는가 결제 내역 및 검색 기능 구현


            3. Server & Client 공통 작업
                3-1. Regdate의 입력 날짜가 바뀌면 즉, 하루가 넘어가면 OrderNumber 새롭게 초기화 구현
                3-2. 같은 제품의 다른 옵션의 경우 Cart & Order 구현 방안 생각할 것
                3-3. Server와 Client에 구현한 모든 이벤트들 Name을 지정하여 구분을 쉽게 할 것, 도구들의 Name으로 이벤트를 만드니 뭐가 어떤 이벤트인지 구분이 어려움
                     물론 #region을 통해 설명을 넣지만 아무래도 한계가 존재
                     (ex: button1_Click(object sender, EventArgs e) → Order_Success_Message(object sender, EventArgs e)


           일단은 여기까지
        */
    }
}

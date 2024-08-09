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
            2. Server
                2-1. Client로부터 수신받은 DataTable을 주문목록창에 띄우기, 동적 UI 구현
                    2-1-1. 주문 내역에서 버튼 별 구별
                    2-1-2. 수량

                2-2. OrderList에서 주문 취소 시 해당 칼럼들을 찾아서 삭제해야함.
                    2-2-1. Tcp/Ip로 수신 후 Temporary로 저장 후 어느 부분에서 실제 DB에 담는지 찾아야함.




            3. Server & Client 공통 작업
                3-1. Regdate의 입력 날짜가 바뀌면 즉, 하루가 넘어가면 OrderNumber 새롭게 초기화 구현
                
                3-3. Server와 Client에 구현한 모든 이벤트들 Name을 지정하여 구분을 쉽게 할 것, 도구들의 Name으로 이벤트를 만드니 뭐가 어떤 이벤트인지 구분이 어려움
                     물론 #region을 통해 설명을 넣지만 아무래도 한계가 존재
                     (ex: button1_Click(object sender, EventArgs e) → Order_Success_Message(object sender, EventArgs e)

                3-4. 경고 처리

           일단은 여기까지
        */
    }
}

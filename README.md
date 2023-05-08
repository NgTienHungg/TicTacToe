# TicTacToe

## I. LÝ THUYẾT VỀ THUẬT TOÁN MINIMAX

### 1. Khái niệm

Thuật toán Minimax (hay còn gọi là Minmax) là một thuật toán đệ quy lựa chọn bước đi kế tiếp. Thuật toán phổ biến trong trò chơi đối kháng trong đó hai người thay phiên đi nước đi của mình như: cờ vua, tic-tac-toe, cờ vây, .... Khi chơi bạn có thể khai triển hết không gian trạng thái nhưng khó khăn chủ yếu là bạn phải tính toán được phản ứng và nước đi của đối thủ mình như thế nào? Cách xử lý đơn giản là bạn giả sử đối thủ của bạn cũng sử dụng kiến thức về không gian trạng thái giống bạn. Giải thuật Minimax áp dụng giả thuyết này để tìm kiếm không gian trạng thái của trò chơi.

### 2. Lịch sử hình thành

Trong những cột mốc đánh dấu sự hình thành và phát triển của trí tuệ nhân tạo, sự hình thành của thuật toán Minimax luôn được gọi tên như sự đóng góp rất lớn cho trí tuệ nhân tạo nói chung và thuật toán ứng dụng trong trò chơi nói riêng.
Claude Shannon, được coi là cha đẻ của lý thuyết thông tin, đã đóng góp quan trọng cho sự phát triển của thuật toán Minimax. Năm 1950, ông đã viết bài báo "Programming a Computer for Playing Chess" (Lập trình một máy tính chơi cờ vua) - bài báo đầu tiên về phát triển một phần mềm máy tính chơi cờ vua. Bài báo trình bày phương pháp sử dụng thuật toán Minimax để lập kế hoạch cho một chương trình chơi cờ vua trên máy tính. Ông đã đề xuất sử dụng một bảng đánh giá vị trí của các quân cờ để tính toán giá trị của các trạng thái trong trò chơi.

Năm 1956, cụm từ “Artificial Intelligence” (trí tuệ nhân tạo) được đề xuất bởi nhà khoa học máy tính John McCarthy tại hội nghị Dartmouth, đánh dấu mốc chính thức ra đời của trí tuệ nhân tạo. McCarthy vừa là cha đẻ của trí tuệ nhân tạo, còn là cha đẻ của ngôn ngữ lập trình Lisp. Trong thời gian ấy, bài báo “The Dartmouth Conference” (hội nghị Dartmouth) của John McCarthy đã đề cập đến việc sử dụng thuật toán Minimax để tạo ra một chương trình chơi trò chơi tic-tac-toe trên máy tính.

Từ đó đến nay, đã có rất nhiều nghiên cứu và bài báo về thuật toán Minimax, có thể kể đến như: “Dynamic programming and minimax algorithms” (Quy hoạch động và thuật toán Minimax) – Bellman, R. (1957); “Analysis of a simple game using minimax” (Phân tích một trò chơi đơn giản sử dụng Minimax) – Knuth, D.E. (1975); “Artificial intelligence: A modern approach” (Trí tuệ nhân tạo – Cách tiếp cận hiện đại) - Russell, S., & Norvig, P. (2010).
Và kể từ ấy, thuật toán Minimax đã được sử dụng rộng rãi trong các trò chơi hai người với lượt đi xen kẽ, và được coi là một trong những thuật toán cơ bản nhất của trí tuệ nhân tạo. Các biến thể của thuật toán này như Alpha-Beta pruning và Monte Carlo Tree Search cũng đã được phát triển để tăng tốc độ tính toán và cải thiện hiệu quả của thuật toán.

### 3. Cách xây dựng thuật toán

#### 3.1. Giải thuật Minimax

Hai đối thủ trong trò chơi được gọi là MIN và MAX luân phiên thay thế nhau đi. MAX đại diện cho người quyết dành thắng lợi và cố gắng tối đa hóa ưu thế của mình, ngược lại người chơi đại diện cho MIN lại cố gắng giảm điểm số của MAX và cố gắng làm cho điểm số của mình càng âm càng tốt. Giả thiết đưa ra MIN và MAX có kiến thức như nhau về không gian trạng thái trò chơi và cả hai đối thủ đều cố gắng như nhau.
Mỗi Node biểu diễn cho một trạng thái trên cây trò chơi. Node lá là Node chứa trạng thái kết thúc của trò chơi.
Giải thuật Minimax thể hiện bằng cách định trị các Node trên cây trò chơi:

• Node thuộc lớp MAX thì gán cho nó giá trị lớn nhất của con Node đó.

• Node thuộc lớp MIN thì gán cho nó giá trị nhỏ nhất của con Node đó.

Từ các giá trị này người chơi sẽ lựa chọn cho mình nước đi tiếp theo hợp lý nhất.

#### 3.2. Các bước giải thuật Minimax

• Nếu như đạt đến giới hạn tìm kiếm (đến tầng dưới cùng của cây tìm kiếm tức là trạng thái kết thúc của trò chơi).

• Tính giá trị của thế cờ hiện tại ứng với người chơi ở đó. Ghi nhớ kết quả.

• Nếu như mức đang xét là của người chơi cực tiểu (nút MIN), áp dụng thủ tục Minimax này cho các con của nó. Ghi nhớ kết quả nhỏ nhất.

• Nếu như mức đang xét là của người chơi cực đại (nút MAX), áp dụng thủ tục Minimax này cho các con của nó. Ghi nhớ kết quả lớn nhất.

#### 3.3. Ví dụ mô phỏng giải thuật Minimax cho trò chơi Tic-Tac-toe

Quy ước:
• MAX đại diện quân đi O.

• MIN đại diện quân đi X.

Trạng thái kết thúc là trạng thái có 3 ô liên tiếp ngang, dọc, chéo có cùng một quân cờ X hoặc O, nếu là X tức MIN thắng còn O tức MAX thắng còn nếu tất cả các ô cờ đều được đi và trạng thái chưa kết thúc thì bàn cờ hòa. Điểm thắng của X là -1, của O là 1, và bàn cờ hòa là 0.

Áp dụng giải thuật Minimax: Từ trạng thái bàn cờ hiện tại ta dự đoán nước đi của trạng thái tiếp theo nếu trạng thái tiếp theo ta tiến hành lượng giá cây trò chơi bằng cách ta tiến hành quét cạn tất cả các trạng thái tiếp theo cho đến lúc gặp trạng thái chiến thắng (Node lá) tính điểm cho Node lá bằng cách:

• Nếu ở trạng thái mà ta gặp chiến thắng nếu đó là lượt đi của quân X thì đánh giá điểm trạng thái đó là -1.

• Nếu ở trạng thái ta gặp chiến thắng nếu đó là lượt đi của quân O thì đánh giá điểm trạng thái đó là 1.

• Nếu là hòa thì điểm trạng thái đó là 0.

Sau đó tính ngược lại cây trò chơi theo quy tắc:

• Nút thuộc lớp MAX thì gán cho nó giá trị lớn nhất của các Node con của Node đó.

• Nút thuộc lớp MAX thì gán cho nó giá trị nhỏ nhất của các Node con của Node đó.

Sau khi lượng giá hết cây trò chơi ta tiến hành chọn bước đi tiếp theo nguyên tắc:

• Nếu lớp tiếp theo là MAX ta chọn Node con có giá trị lớn nhất.

• Nếu lớp tiếp theo là MIN ta chọn Node con có giá trị nhỏ nhất.

### 4. Ưu điểm và nhược điểm

#### 4.1. Ưu điểm

• Đảm bảo tìm được chiến lược tối ưu cho một người chơi trong trò chơi hai người với lượt đi xen kẽ.

• Dễ hiểu và áp dụng.

• Tính toán độ chính xác cao khi số lượng các trạng thái trong trò chơi không quá lớn.

• Có thể được mở rộng để giải quyết các trò chơi phức tạp hơn bằng cách sử dụng các biến thể như Alpha-Beta pruning hoặc Monte Carlo Tree Search.

#### 4.2. Nhược điểm

• Độ phức tạp tính toán của thuật toán tăng rất nhanh khi kích thước của cây trò chơi tăng, làm cho việc tính toán trở nên không thực tế cho các trò chơi lớn.

• Cần phải tính toán toàn bộ cây trò chơi trước khi đưa ra quyết định, làm tốn thời gian và tài nguyên tính toán.

• Chỉ có thể được áp dụng cho các trò chơi với lượt đi xen kẽ và có số lượng trạng thái hữu hạn, không áp dụng cho các trò chơi thời gian thực hoặc trò chơi với số lượng trạng thái vô hạn.

Tóm lại, thuật toán Minimax là một thuật toán tìm kiếm cây trò chơi phổ biến và mạnh mẽ cho các trò chơi hai người với lượt đi xen kẽ. Tuy nhiên, nó có những giới hạn về khả năng áp dụng cho các trò chơi lớn và phức tạp hơn

### 5. Các thư viện sử dụng

Các thư viện sử dụng để triển khai thuật toán Minimax phụ thuộc vào ngôn ngữ lập trình được sử dụng. Dưới đây là một số thư viện phổ biến được sử dụng trong các ngôn ngữ lập trình khác nhau:
• Python:

- Pygame: một thư viện hỗ trợ viết game với Python, bao gồm các phương thức hỗ trợ cho thuật toán Minimax.
- Numpy: thư viện hỗ trợ xử lý các phép tính toán số học và đại số tuyến tính, được sử dụng trong thuật toán Minimax.
  • Java:
- JGameGrid: một thư viện hỗ trợ viết game với Java, bao gồm các phương thức hỗ trợ cho thuật toán Minimax.
- JME: thư viện đồ họa 3D dành cho Java, cũng có thể được sử dụng để triển khai thuật toán Minimax trong các trò chơi.
  • C++:
- SFML: một thư viện đồ họa và âm thanh dành cho C++, cũng hỗ trợ thuật toán Minimax.
- SDL: một thư viện đa nền tảng hỗ trợ đồ họa, âm thanh và nhập liệu dành cho C++, có thể được sử dụng để viết các trò chơi và triển khai thuật toán Minimax.
  • C#:
- Unity Game Engine: là một trong những công cụ phổ biến nhất để phát triển game trên nhiều nền tảng, bao gồm cả nền tảng di động. Unity cung cấp một số thư viện và phương thức hỗ trợ để triển khai thuật toán Minimax trong các trò chơi.
- SharpDX: là một thư viện dành cho C# cho phép truy cập trực tiếp vào DirectX API. Thư viện này hỗ trợ triển khai các trò chơi 3D và cung cấp một số phương thức hỗ trợ cho thuật toán Minimax.
- XNA Game Studio: là một bộ công cụ phát triển game dành cho Microsoft Windows và Xbox 360. XNA cung cấp một số thư viện và phương thức hỗ trợ cho thuật toán Minimax.
- AForge.NET: là một thư viện hỗ trợ xử lý hình ảnh và thị giác máy tính, cũng có thể được sử dụng để triển khai thuật toán Minimax trong các trò chơi.

## II. Sản phẩm.

### 1. Giới thiệu sản phẩm.

Tic – tac – toe là sản phẩm Game làm bằng Unity kết hợp với xây dựng bot AI bằng thuật toán Minimax trên ngôn ngữ C#.
Sản phẩm Game hoàn thiện với hình ảnh và animation rất chỉnh chu cũng như tính thông minh của Bot AI qua việc xây dựng thuật toán Minimax.
Game có 2 chức năng là chơi 2v2 hoặc chơi với Bot. Bot game có 3 level là Easy, Medium và Hard. Tuỳ vào độ khó mà thuật toán được xây dựng theo độ sâu khác nhau. Với mức độ Hard, chắc chắn người chơi không thể thắng được Bot. Mà chỉ có thể thua hoặc hoà.

### 2. Ứng dụng của thuật toán trong sản phẩm.

Trên đây là đoạn code để kiểm tra mode chơi hiện tại và quyết định nước đi tiếp theo cho AI:

• Nếu Mode = Easy => Ta sẽ đi random 1 trong các vị trí trống còn lại trên bảng

• Nếu Mode = Medium => Ta sử dụng Minimax không sử dụng depth

• Nếu Mode = Hard => Ta sử dụng Minimax có depth (Tìm ra nước đi tốt nhất và ngắn nhất)

Với Minimax không sử dụng depth:
Thuật toán sẽ trả về Result đơn giản là các giá trị gốc mà mình quy định:

• -10 nếu nước đi của Player thắng

• 10 nếu nước đi của AI thắng

• 0 nếu cả 2 hoà

Với Minimax có tính depth

• Như ta thấy thì tại dòng return (result – depth), giá trị điểm thu được nếu đi theo con đường này bị giảm nếu đi càng sâu.

• Như vậy nếu có nhiều nước đi cùng cho ra kết quả thắng, AI sẽ đi cách đi ngắn nhất (ít lượt chơi nhất).

### 3. Giới thiệu một số hình ảnh về Game.

Figure 1 Màn hình chính của game

Figure 2 Chọn độ khó khi chơi với Bot

Figure 3 Lượt đi của Bot

Figure 4 Người chơi bị thua

Figure 5 Hình ảnh hoà khi chơi 2v2

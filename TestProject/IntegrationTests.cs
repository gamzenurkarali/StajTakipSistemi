using Xunit;
using Moq;
using Microsoft.AspNetCore.SignalR;
using StajyerTakipSistemi.Hubs;
using StajyerTakipSistemi.Web.Models;

public class IntegrationTests
{
    [Fact]
    public async Task SendMessage_SendsMessageToReceiver()
    {
        var dbContextMock = new Mock<StajyerTakipSistemiDbContext>();
        var hubContextMock = new Mock<IHubContext<ConnectedHub>>();
        var clientProxyMock = new Mock<IClientProxy>();

        clientProxyMock.Setup(c => c.SendCoreAsync(It.IsAny<string>(), It.IsAny<object[]>(), default)).Returns(Task.CompletedTask);
        hubContextMock.Setup(c => c.Clients.All).Returns(clientProxyMock.Object);

        var chatHub = new ConnectedHub(dbContextMock.Object, hubContextMock.Object);

        var senderGuid = Guid.NewGuid().ToString();
        var receiverGuid = Guid.NewGuid().ToString();
        var message = "Test message";

        await chatHub.SendMessage(senderGuid, receiverGuid, message);

        clientProxyMock.Verify(c => c.SendCoreAsync("ReceiveMessage", new object[] { senderGuid, receiverGuid, message, It.IsAny<long>() }, default), Times.Once);
    }
}



























































//Bu test, ConnectedHub sınıfının SendMessage metodunun doğru çalışıp çalışmadığını kontrol eder. SendMessage metodunun, bir mesajı alıcıya göndermek için Clients.All.SendAsync yöntemini çağırması gerekiyor. Bu testte, SendMessage metodunun istenilen parametreleri aldığı ve Clients.All.SendAsync yönteminin bir kez çağrıldığı doğrulanıyor.

//Testin adımları şu şekildedir:

//Arrange(Düzenleme): Mock veritabanı bağlamı (dbContextMock) ve bir IHubContext<ConnectedHub> mock nesnesi (hubContextMock) oluşturulur.Ayrıca, IClientProxy için mock bir nesne (clientProxyMock) oluşturulur.Bu mock nesneler, test sırasında gerçek nesnelerin yerine geçecek ve davranışlarını kontrol etmek için kullanılacaktır.

//Act (İşlem): ConnectedHub sınıfının bir örneği (chatHub) oluşturulur ve SendMessage metodu çağrılır. Bu metod, belirli bir gönderici ve alıcıya bir mesaj gönderir ve bu mesajı veritabanına kaydeder.

//Assert (Doğrulama): clientProxyMock nesnesi üzerindeki SendCoreAsync yönteminin, doğru parametrelerle bir kez çağrıldığı doğrulanır. Bu, SendMessage metodunun mesajı alıcıya doğru bir şekilde gönderdiğini doğrular.

//Bu test, ConnectedHub sınıfının mesaj gönderme işlevselliğini doğrular ve bu işlevselliğin gelecekte yapılan değişikliklerden etkilenmediğini sağlar.
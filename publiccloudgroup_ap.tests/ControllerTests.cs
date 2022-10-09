namespace publiccloudgroup_ap.tests
{
    [TestFixture]
    public class Tests
    {

        //Some tests for demonstration purpose.

        Mock<IVmOperations> _mockOperations;
        CloudManagementController _controller;

        [SetUp]
        public void Setup()
        {
            //Mocking the depencies=>
            _mockOperations = new Mock<IVmOperations>();
            _controller = new CloudManagementController(_mockOperations.Object);
        }

        [Test]
        public async Task GetVmList_Returns_BadRequest()
        {
            //arrange
            _mockOperations.Setup(x => x.GetAllVmIntances()).ReturnsAsync((false, (IList<InstanceDto>)Dummies.dummyInstanceList, ""));

            //act

            var result = await _controller.GetVmList();
            var objectResult = (BadRequestObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());

        }


        [Test]
        public async Task GetVmList_Returns_Ok()
        {
            //arrange
            _mockOperations.Setup(x => x.GetAllVmIntances()).ReturnsAsync((true, (IList<InstanceDto>)Dummies.dummyInstanceList, "success"));

            //act
            var result = await _controller.GetVmList();
            var objectResult = (OkObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
        }


        [Test]
        public async Task StartSelectedVm_Returns_Ok()
        {
            //arrange
            StartRequestModelDto startRequestModelDto = new() { InstanceName = "instance-1", Zone = "america" };
            _mockOperations.Setup(x => x.StartSelectedVm(startRequestModelDto)).ReturnsAsync((true, "success"));

            //act
            var result = await _controller.StartSelectedVm(startRequestModelDto);
            var objectResult = (OkObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public async Task StartSelectedVm_Returns_BadRequest()
        {
            //arrange
            StartRequestModelDto startRequestModelDto = new() { InstanceName = "instance-1", Zone = "america" };
            _mockOperations.Setup(x => x.StartSelectedVm(startRequestModelDto)).ReturnsAsync((false, "failed"));

            //act
            var result = await _controller.StartSelectedVm(startRequestModelDto);
            var objectResult = (BadRequestObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task StopSelectedVm_Returns_BadRequest()
        {
            //arrange
            StopRequestModelDto stopRequestModelDto = new() { InstanceName = "instance-1", Zone = "america" };
            _mockOperations.Setup(x => x.StopSelectedVm(stopRequestModelDto)).ReturnsAsync((false, "failed"));

            //act
            var result = await _controller.StopSelectedVm(stopRequestModelDto);
            var objectResult = (BadRequestObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
        }


        [Test]
        public async Task StopSelectedVm_Returns_Ok()
        {
            //arrange
            StopRequestModelDto stopRequestModelDto = new() { InstanceName = "instance-1", Zone = "america" };
            _mockOperations.Setup(x => x.StopSelectedVm(stopRequestModelDto)).ReturnsAsync((true, "success"));

            //act
            var result = await _controller.StopSelectedVm(stopRequestModelDto);
            var objectResult = (OkObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public async Task SuspendSelectedVm_Returns_Ok()
        {
            //arrange
            SuspendRequestModelDto suspendRequestModelDto = new() { InstanceName = "instance-1", Zone = "america" };
            _mockOperations.Setup(x => x.SuspendSelectedVm(suspendRequestModelDto)).ReturnsAsync((true, "success"));

            //act
            var result = await _controller.SuspendSelectedVm(suspendRequestModelDto);
            var objectResult = (OkObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
        }


        [Test]
        public async Task SuspendSelectedVm_Returns_BadRequest()
        {
            //arrange
            SuspendRequestModelDto suspendRequestModelDto = new() { InstanceName = "instance-1", Zone = "america" };
            _mockOperations.Setup(x => x.SuspendSelectedVm(suspendRequestModelDto)).ReturnsAsync((false, "success"));

            //act
            var result = await _controller.SuspendSelectedVm(suspendRequestModelDto);
            var objectResult = (BadRequestObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task ResumeSelectedVm_Returns_BadRequest()
        {
            //arrange
            ResumeRequestModelDto resumeRequestModelDto = new() { InstanceName = "instance-1", Zone = "america" };
            _mockOperations.Setup(x => x.ResumeSelectedVm(resumeRequestModelDto)).ReturnsAsync((false, "success"));

            //act
            var result = await _controller.ResumeSelectedVm(resumeRequestModelDto);
            var objectResult = (BadRequestObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task ResumeSelectedVm_Returns_Ok()
        {
            //arrange
            ResumeRequestModelDto resumeRequestModelDto = new() { InstanceName = "instance-1", Zone = "america" };
            _mockOperations.Setup(x => x.ResumeSelectedVm(resumeRequestModelDto)).ReturnsAsync((true, "success"));

            //act
            var result = await _controller.ResumeSelectedVm(resumeRequestModelDto);
            var objectResult = (OkObjectResult)result;

            //assert
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult, Is.TypeOf<OkObjectResult>());
        }
    }
}
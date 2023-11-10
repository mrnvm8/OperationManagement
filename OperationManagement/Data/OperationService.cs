namespace OperationManagement.Data
{
    public class OperationService
    {
        public List<Operation> _operationsList = new();

        public void AddOperations(Operation operation)
        {
            //Get the last opeation
            var getLastOperation = _operationsList.LastOrDefault();

            //Since this there is ID, I need a new operation ID every time I save it.
            //get the last value Id and Add 1,
            // if the is not operation existing make operationID 1;
            operation.OperationID = getLastOperation == null ? 1 : getLastOperation!.OperationID + 1;
            //No device Assign yet
            operation.Device = null;
            //con

            //Adding the operation to the lits
            _operationsList.Add(operation);
        }

        public void RemoveOperations(int OperationId)
        {
            //get the operation by Id
            var operation = _operationsList
                .FirstOrDefault(x => x.OperationID.Equals(OperationId));

            //remove the opearation from the list
            _operationsList.Remove(operation!);
        }
        public void AddDeviceToOperation(int operationId, Device device)
        {
            //get the operation by Id
            var operation = _operationsList
                .FirstOrDefault(x => x.OperationID.Equals(operationId));

            //add device to the operation
            operation!.Device = new Device
            {
                Name = device.Name,
                DeviceType = device.DeviceType
            };
        }
    }
}

package send;

import send.CareFunds;
import java.io.FileReader;
import java.io.IOException;
import java.nio.charset.Charset;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Executors;
import java.util.concurrent.ExecutorService;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.microsoft.azure.eventhubs.ConnectionStringBuilder;
import com.microsoft.azure.eventhubs.EventData;
import com.microsoft.azure.eventhubs.EventHubClient;
import com.microsoft.azure.eventhubs.EventHubException;
public class SendMessage {

	public static void main(String[] args)  throws EventHubException, ExecutionException, InterruptedException, IOException {
		// TODO Auto-generated method stub
		final ConnectionStringBuilder connStr = new ConnectionStringBuilder()
		        .setNamespaceName("dissertationns")
		        .setEventHubName("dissertationhub")
		        .setSasKeyName("RootManageSharedAccessKey")
		        .setSasKey("sUvI0KO768XZBBd5sANyIukAPfwMyJIcejGrSshRmHU=");
		//"Endpoint=sb://dissertationns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=sUvI0KO768XZBBd5sANyIukAPfwMyJIcejGrSshRmHU="
		
		final Gson gson = new GsonBuilder().create();
		final ExecutorService executorService = Executors.newWorkStealingPool();
		final EventHubClient ehClient = EventHubClient.createSync(connStr.toString(), executorService);

		for (int i = 0; i < 100; i++) {
			
			System.out.println("JSON File Path: ");
			String filepath = "C:\\Users\\admin\\Downloads";
			String filename = "elderlyservices.json";
			String fpath = filepath +"\\"+ filename;
			FileReader reader = new FileReader(fpath);
			CareFunds carefunds = gson.fromJson(reader, CareFunds.class);
			String payload = "Message " + Integer.toString(i);
			byte[] payloadBytes = gson.toJson(payload).getBytes(Charset.defaultCharset());
			EventData sendEvent = EventData.create(payloadBytes);
			ehClient.sendSync(sendEvent);
		}
		
		// close the client at the end of your program
		ehClient.closeSync();

	}

}

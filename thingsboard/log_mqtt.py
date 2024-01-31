import paho.mqtt.client as mqttClient
import time
from datetime import datetime

def on_connect(client, userdata, flags, rc):

    if rc == 0:

        print("Connected to broker")

        global Connected                #Use global variable
        Connected = True                #Signal connection

    else:

        print("Connection failed")

def on_message(client, userdata, message):
    #print "Message received: "  + message.payload
    with open('loggedmqtt.txt','a+') as f:
         f.write(str(datetime.now()) + ","  + message.topic + "," + str(message.payload) + "\n")

Connected = False   #global variable for the state of the connection

broker_address= "codelcloud.com"  #Broker address
port = 1883                         #Broker port

client = mqttClient.Client("Python")               #create new instance
#client.username_pw_set(user, password=password)    #set username and password
client.on_connect= on_connect                      #attach function to callback
client.on_message= on_message                      #attach function to callback
client.connect(broker_address,port,60) #connect
client.subscribe("et301/+/data") #subscribe
client.loop_forever() #then keep listening forever
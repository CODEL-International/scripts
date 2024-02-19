import json
import paho.mqtt.client as mqtt
import time
import datetime
import itertools

def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))

def on_publish(client, userdata, mid):
    print("Message published")

client = mqtt.Client()
client.on_connect = on_connect
client.on_publish = on_publish
client.connect("63.35.197.6", 1883, 60)

with open('loggedmqtt.txt', 'r') as file:
  for line in file:
    if (line == "\n"):
      continue

    data = line.strip().split(',', 2)
    sdatetime, topic, message = data[0], data[1], data[2]

    jmsg = json.loads(message.replace("b\'","").replace("\\n\'","").replace("\'",""))

    bSkip2 = False
    json_msg_pt1 = (dict(itertools.islice(jmsg.items(),0,14,1))) #From 0 to 14th item, stepping 1 - Working Round bug in tb
    json_msg_pt2 = (dict(itertools.islice(jmsg.items(),14,30,1)))  # From 15th item to 30th (over end), stepping 1 - Working Round bug in tb

    if not json_msg_pt2:
       bSkip2 = True;

    ts = time.mktime(datetime.datetime.strptime(sdatetime,"%Y-%m-%d %H:%M:%S.%f").timetuple())
    jts = {"ts": round(ts*1000)}
    json_msg_pt1.update(jts)
    json_msg_pt2.update(jts)

    payload = {'topic': topic, 'data': json.dumps(json_msg_pt1)}
    print(payload)
    if not bSkip2:
       payload = {'topic': topic, 'data': json.dumps(json_msg_pt2)}
       print(payload)
    print("\n")
    #payload = {'topic': topic, 'data': json.dumps(dict(itertools.islice(jmsg.items(),0,14,1)))}  #From 0 to 14th item, stepping 1
    #print(payload)

    #payload = {'topic': topic, 'data': json.dumps(dict(itertools.islice(jmsg.items(),14,30,1)))}  # From 15th item to 30th (over end), stepping 1
    #print(payload)

    client.publish(topic, json.dumps(json_msg_pt1))
    if not bSkip2:
      client.publish(topic, json.dumps(json_msg_pt2))

    time.sleep(2)

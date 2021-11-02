# Training Intelligent game Agents through Competitive Reinforcement Learning


<img width="674" alt="Screenshot 2021-08-23 at 9 51 26 PM" src="https://user-images.githubusercontent.com/43823795/138601478-590dcc56-a725-406c-8754-aaa39ecf8253.png">

## MORE DETAILED DESCRIPTION IN THE PDF FILE

### Abstract

This diploma thesis deals with the implementation of a simulation in
three dimensions, in which there exist some agents. These agents are
trained to perform specific tasks. Using the Unity3d platform in
conjunction with the ml-agents library provided, we construct a
simulation environment suitable to carry through the needs of our
training requirements. The technique of artificial intelligence used is
reinforcement learning, one of the branches of the broader concept
called machine learning. In the theoretical part, there is an analysis
of reinforcement learning and a comparison with other subsets of machine
learning, such as supervised learning and unsupervised learning. More
specifically, from the range of techniques provided by reinforcement

learning, we use self-play, in which a simulation that contains two
teams of agents competing for the same or a different purpose as
opponents. The ml-agents library mentioned above provides two
algorithms, PPO and SAC, for which an extensive analysis is made both in
the mathematical background and the practical one. Training in both
cases also requires an in-depth analysis of a large number of
hyperparameters, a trademark for reinforcement learning. The
implementation is analysed from its front-end, ie at the level of the
gaming machine that contains the environment, up to the back-end, ie the
neural network, a necessary tool for achieving agent learning. Finally,
the experiments are presented with an extensive comparison of the
algorithms used and their hyper-parameter tuning.

**Keywords**: reinforcement learning, rl, self-play, machine learning,
ml, ml-agents, Unity3d, PPO, SAC

![ezgif com-gif-maker](https://user-images.githubusercontent.com/43823795/139948987-b38edd3f-8ca8-4671-b1e9-e46851793bfb.gif)


### Introduction

#### 1.1. Problem description

In today's world, the abstract term Artificial Intelligence (AI) has
taken over everything. Every device at our disposal uses some AI
technology. The GPS in our phones is able to find the optimal path for
us to reach our destination, using ai pathfinding algorithms. The
smartphone faces recognition technologies that use object detection. The
NPC (Non-player character) opponents we face in the video games we play
for our entertainment. The virtual/extended reality (VR) simulation
technologies that rose the recent years. Even the robotic vacuum
cleaners that clean our houses by mapping them using ray-cast sensors.
And countless other applications which are part of our lives for
educational purposes, entertainment or to make our lives easier. These
technologies have been created to make our everyday lives better by
solving our daily problems or even eternal unsolved problems. This
automation isn't something new, devices that made our life easier were
one of our priorities since 1771 when the first fully automated
watermill was invented. Although the implementations mentioned above
differ in one specific detail. They don’t just replace manpower with
machines, instead, they develop artificial neural networks that get
trained in order to achieve better or even unexpected results. The main
objective of AI research is to imitate the human policy to a level that
exceeds human capabilities. More and more new developers tend to
approach AI as a subject to create such technologies, so it felt needed
to open the doors and make easy access to the world of Reinforcement
Learning Training. As a new developer, it is hard to know where to
start, what to learn first and how to provide for the scientific
community. In order for a researcher to dedicate their time efficiently
in the matter and not get lost in the vast branch of AI, they need
guidance. That’s where the issue of the lack of guidance occurred and
the idea of making this diploma thesis rose.


![ezgif com-gif-maker](https://user-images.githubusercontent.com/43823795/139949720-87fb4f0a-1114-46fa-9552-3aa4ae9d6805.gif)


#### 1.2. Purpose of the research

#### 

The main purpose of this research is to analyse the given algorithms and
the theory behind the self-play learning method in order subtract useful
information for our implementations. By doing so wi will define the
optimal selection of techniques in order to achieve the best possible
training results inside our simulation. The hyperparameter tuning
testing allows us to distinguish how to scale each parameter according
to the situation. By explaining and then using the
theoretical/mathematical background of the reinforcement learning
algorithms we are able to make more clear and understandable
conclusions. A simple description of the experiments is that inside an
environment where humanoid agents exist, we are training those agents in
order to complete several tasks we give them. Those tasks are mainly to
reach some targets before any of the other agents do. In order to
achieve these training results, we are basically using neural network
training models in parallel to some reinforcement learning methods. In
conclusion, optimising those behaviours is our number one priority.

#### 1.3. Contributions

#### 

As mentioned before it felt necessary to make a deep and step by step
analysis of a complete simulation using the selected tools. The material
provided online seems to be either too theoretical or way too practical,
which means that no mathematical background is explained in the existing
implementations. As a matter of fact, many new developers struggle to
achieve acceptable results due to the lack of guidance and
understanding. Following a tutorial on how to implement such a
simulation may occur to a working result but most probably it won’t be
close to optimal. The problem is that copying someone’s implementation
doesn’t necessarily mean that minor changes will have the same standards
of hyperparameter tuning. It felt needed to strive into explaining the
core of such a procedure. Thus this thesis is going to contribute to the
scientific community by providing easy access for new researchers to
test their ideas in a complete RL testing environment. Tools
specifically made for such simulations were created in process of our
work and were published on the web for everyone to use.

#### 1.4. Thesis structure

##### 

Now that we made a quick description of the problem and the purpose of
its solution we will dive into the matter. First, we will state some
terms from the theory that we are going to use regularly till the end of
the thesis. We are going to clarify the relationship between the terms
of Artificial Intelligence, Machine Learning, Reinforcement Learning,
and Self-Play and make a theoretical description of how those branches
handle their problems with examples. Also, we are going to make a
mathematical analysis of the reinforcement learning algorithms we are
going to use by pointing out the key elements that make them so
successful in their training sessions. Next, we will present the
platforms used for both the implementation and the training, in a way
that is going to be understandable for someone who’d like to use them in
the future. By then we will be ready to continue with the discussion of
the results made after the experiments. Finally, the comparison of all
the variants and all the remarks made in the process of the
implementation will be discussed. Each problem is unique, but similar
problems require similar solutions. That’s why we are going to specify
how to tune an implementation in such a way that every problem is easy
to handle using the techniques in our arsenal.

### 2\. Theoretical background & Methodology

Artificial Intelligence or AI is an abstract term, which means that when
we refer to it, it is not clear what technique we are talking about.
Based on theory, AI is the broadest set that contains all the other
branches of the subject. One of the children of AI, is Machine Learning
(ML), which in turn is divided into its own subcategories based on the
way of training used. The detailed sets are shown in the VEN diagram
below:

Artificial Intelligence (AI): Any technique that enables computers to
mimic human intelligence using logic.

Machine Learning (ML): provides systems the ability to automatically
learn and improve from experience without being explicitly programmed. 

Supervised learning (SL) is the machine learning task of learning a
function that maps an input to an output based on example input-output
pairs. In SL data is tagged by a human in order for the system to
evaluate the results

Unsupervised learning (UL) is a type of algorithm that learns patterns
from untagged data. UL exhibits self-organisation that captures patterns
as neuronal predilections or probability densities.

A great analysis of the AI family tree was made by
[<span class="underline">\[3\]</span>](\\l).

#### 2.1. Reinforcement Learning

#### 

Reinforcement learning (RL) is an area of machine learning concerned
with how intelligent agents ought to take actions in an environment in
order to maximize the notion of cumulative reward. Reinforcement
learning is one of three basic machine learning paradigms, alongside
supervised learning and unsupervised learning,
[<span class="underline">\[11\]</span>](\\l).

From the great results of beating Atari games to the “Deep Minds”
victories using Alphago in chess, breakthroughs in robotic arm
manipulation and even beating professional e-sports athletes in games
like Dota, RL has literally exploded in recent years. People from many
different backgrounds have started using deep neural networks to solve a
wide range of new tasks including how to learn intelligent behaviours in
dynamic ( that change as time pass ) environments. In 2017 Peter Emil
gave a very inspiring demonstration and showed a video of a robot
cleaning a living room, bringing a bottle of beer, and basically doing a
whole range of mundane tasks that robots in sci-fi movies can do without
question. At the end of the presentation, it was revealed that the robot
was manually controlled by a human. The takeaway from the demonstration
was to prove that the robots, we humans have been building for decades
now, are fully capable of doing a wide range of useful tasks but the
problem is that we haven’t embedded them with the needed intelligence to
do those things on their own. So basically creating useful
state-of-the-art robotics is not a hardware problem, but instead, it’s a
software one.

In comparison with Unsupervised Learning, Reinforcement learning is
different in terms of goals. While the goal in unsupervised learning is
to find similarities and differences between data points, in
reinforcement learning the goal is to find a suitable action model that
would maximize the total cumulative reward of the agent. Although RL and
UL are both sub-branches of machine learning, the problems that can be
solved by both are a rare cause of the major difference that an RL model
works with dynamic environments that change over time due to some
external factors or the agent itself and UL models are static and their
main objective is to extract as much data as possible in order to
categorise or use the info for a further purpose
[<span class="underline">\[10\]</span>](\\l).

The tricky part comes when we make the comparison with Supervised
Learning. Though both supervised and reinforcement learning use mapping
between input and output, unlike supervised learning where feedback
provided to the agent is the correct set of actions for performing a
task, reinforcement learning uses rewards and punishment as signals for
positive and negative behaviour. So if we are doing supervised learning
on a static training dataset then we can run a stochastic gradient
descent optimiser in that data and we can be pretty sure that our model
will converge to a pretty decent local optimum. That is not the case in
RL [<span class="underline">\[10\]</span>](\\l). Let’s say for example
that we want to train a network that plays the game tic-tac-toe. In
supervised learning, we would have an experienced human player play the
game for a couple of hours and then we would create a dataset where we
log all the frames that human is seeing on the screen, as well as the
actions that he takes in response to the moves that machine makes. We
then would feed those inputs in the very simple neural network and the
output would produce a bunch of several simple actions the agents can
take ( to put an “X” or an “O” in one of the empty remaining slots ).
This is a simple training on the dataset of the human gameplay using
back-propagation. Using this technique two significant issues occur all
of a sudden. First, the need for the creation of a dataset is a downside
as it is not always an easy thing to do nor even possible. Secondly,
this training is going to imitate human behaviour but it will never
surpass it. So if the trained neural network faces a better opponent
than the human it got its inputs from, then the game is over before it
even started.

In RL we can make an agent play a game entirely by itself. The framework
of RL and supervised learning are surprisingly similar. We still have an
input frame we run through some Neural Network and the network produces
an output action. The only difference is that now we don’t actually know
the target label so we don’t know in any situation whether we should
have done for example an “X” or an “O”, in a specific slot, in the
tic-tac-toe game. The reason is that we don’t have a dataset to train
on. In RL the network that transforms input to output actions is called
a policy network. One of the simplest ways to train a policy network is
a method called policy gradients. In this approach, we start with a
completely random network. We then feed that network a state of the game
and it produces a random action for our agent to take ( in our case an
“X” or an “O” in a specific empty slot ) and sends that action back to
the game engine. Then the next state is produced based on the action and
so on. Because the output is a distribution of the probabilities of all
the possible actions, the agent won’t always repeat the same actions.
This will allows the agent to discover better reward tactics and form
better behaviour.

We want our agent to learn entirely by itself. The only feedback we are
going to give is the scoreboard and some knowledge of the environment
the agent lies in. These are called “reward” and “observations”
respectively. Each time the agent loses a game, it gets a negative
reward also known as a penalty ( for example -1 ). On the other hand, if
the agent manages to win it gets a positive reward ( for example +1 ).
We can apply rewards in the middle of the games as well to guide the
agent into completing the task faster. The entire goal of the agent is
to optimise its policy to receive as much reward as possible. So in
order to train our policy network, the first thing we’re gonna do is to
collect a bunch of experience, those are the observations we referred to
a while ago. This whole bunch is then fed into the network and the
engine produces a sequence of actions. These actions at first may seem
random but with some certain luck, in the process, some of them might
return a bit of reward and so the behaviour will start getting formed.
As time passes more and more reward is probably going to get our agent’s
attention and at some point, the artificial behaviour is going to be
fully structured. Of course, there is a possibility for our training to
get stuck and not proceed further. That's why we use the algorithms we
are going to discuss later to avoid such dangers for our learning
procedure.

During training, the NN is structured with no other than the main
objective of optimising the mean curriculum reward the agents get as
time passes. In parallel, the standard deviation of the reward is also a
second parameter that is optimised. That way we achieve a high mean
reward on a regular basis due to the low standard deviation so the
results are more stable.

Following in the graph is the loop that runs during training. Starting
from the agent that took an action at a specific time t, we have a
change of state inside the environment as the action may have altered
it. Also, a reward is given to the agent based on the new state ( from
\(S_{t}\) to \(S_{t + 1}\) ) that occurred. This reward may even be
negative which implies a penalty for the agent. Then the new state and
the reward are given back to the agent in order for the process to
continue. This procedure runs in a loop for as long as it needs for the
training to return the results we want.


Each RL model consists of the following ingredients:

  - Environment: Physical world in which the agent operates

  - State(\(S_{t}\)): Current situation of the environment in general

  - Action(\(A_{t}\)): one of the available interactions, the agent can
    take, out of the action space. This interaction may affect the
    environment, other agents, to the agent itself.

  - Action Space: All the available interactions for our agent(s),
    during the current state.

  - Reward(\(R_{t}\)): Feedback from the environment to the agent based
    on its actions

  - Policy: Method to map the agent’s state to actions

  - Agent:

The agent is technically the ‘Actor’ inside our scene, it is the entity
we are going to train in order to perform our task. While training it
develops a neural network that contains the policy we are interested in.
When we apply that policy to the agent, it is going to produce a
behavior that will allow the agent to interact in a certain way with the
environment. During the training process, we subtract several variants
of the behaviour in order to analyze them and understand how the agent
managed to finally learn the wanted task. Each agent consists of the
following elements

Observations: The knowledge of the agent about specific parameters
inside the environment is limited to the developer’s desire.

Actions: The carrying-out of a decision on the part of an agent within
the environment. The action may affect the environment, other agents, or
the agent itself.

Policy - The decision-making mechanism, typically a neural network
model.

In each step, an agent can receive a constant amount of observations and
obtains a pool of actions depending on its current policy and the state
of the environment. The policy changes based on the reward the
environment returns back to the agent after he takes an action. There
are many techniques we can use to upgrade RL training, such as the
algorithms we are going to discuss next. By doing so we expect better
results in terms of training time and accuracy.

Policy works like a function, as it returns an action depending on the
state of the environment the agent faces. 

#### 2.2. Algorithm Analysis

#### 

##### **2.2.1.** **[Proximal Policy Optimization (PPO)](https://blog.openai.com/openai-baselines-ppo/) **

##### 

The PPO algorithm was introduced by the OpenAI team in 2017 and quickly
became one of the most popular RL methods surpassing the Deep-Q learning
method. It involves collecting a small batch of experiences interacting
with the environment and using that batch to update its decision making
policy. Once the policy is updated with this batch, the experiences are
thrown away and a newer batch is collected with the newly updated
policy. This is the reason why it is an “on-policy learning” approach
where the experience samples collected are only useful for updating the
current policy once.

The key contribution of PPO is ensuring that a new update of the policy
does not change it too much from the previous policy. This leads to less
variance in training at the cost of some bias, but ensures smoother
training and also makes sure the agent does not go down an unrecoverable
path of taking senseless actions.

One of the problems that reinforcement learning suffers from is that the
training data that is generated is itself dependent on the current
policy because our agents is generating it’s own training data by
interacting with the environment rather than relying on a static data
set as in the case of supervised do. This means that the data
distributions of our observations and rewards are constantly changing as
our agent learns which is a major cause of instability in the whole
training process. Apart from having this problem with varying training
data distributions reinforcement learning also suffers from a very high
sensitivity to hyper-parameter tuning and initialisation. In some cases
it’s kind of intuitive why this happens, because imagine that your
learning rate is too large, then you can have a policy update that
pushes your policy network into a region of the parameter space where
it’s going to collect the next batch of data under a very poor policy
causing it to never recover again. In order to address many of these
problems in reinforcement learning the team of Open AI designed a new
reinforcement learning algorithm that is called Proximal policy
Optimization or PPO. The core purpose behind PPO is to strike the
balance between easy of implementation, sample efficiency and ease of
tuning.

The first thing to realise about PPO is that it is what we call a policy
gradient method. Unlike popular key learning approaches, that can learn
from stored offline data, PPO learns online. And this means that it
doesn’t use a replay buffer to store past experiences, but instead it
learns directly from whatever its agent encounters in the environment.
Once a batch of experience has been used to do a gradient update the
experience is then discarded and the policy moves on. Thus policy
gradient methods are typically less sample efficient than Q-learning
methods because they only use the collected experience once for doing an
update.


##### **2.2.2. Soft Actor-Critic (SAC)**

The second Algorithm we are using in our implementations is the Soft
Actor-Critic Algorithm, also provided by the OpenAI team. Soft Actor
Critic (SAC) is an algorithm that optimises a stochastic policy in an
off-policy way, forming a bridge between stochastic policy optimization
and Deep Deterministic Policy Gradient (DDPG-style) approaches. Sac is
also an actor critic method similar to DDPG and TD3. About the name,
soft means entropy regularised, which plays an important role to the
conversions of the algorithm inside the neural network. Although the
Algorithm is considered an off-policy algorithm, it actually can use a
replay buffer which is an important criterion of it’s structure. This
replay buffer creates the similarity we mentioned before, with TD3 and
DDPG.

By adding entropy regularisation the algorithm favours exploration. So
it allows us to converge to a better optimum. Otherwise the issue of
sticking into a local minimum would be crucial for our training.

As of the stochastic actor characteristic, it is worth mentioning that
there are implementations that use a deterministic actor instead. In
that case SAC becomes exactly the same as TD3, because this removes the
entropy regularisation term and so the decisions are strict.

In the following graph we can distinguish the differences and
relationships between the mentioned algorithms, in terms of their
structure characteristics.

The TRPO and PPO approach: stochastic policies, on-policy, low sampling
efficiency , stable

The DDPG and TD3 approach: deterministic policies, replay buffer, better
sample efficiency, unstable.

The SAC approach: stochastic policies, replay buffer, entropy
regularisation, stable and sample efficient.

Stochastic Policy : means that for every state you do not have
clear defined action to take but you have probability distribution for
actions to take from that state.

Off-Policy: an off-policy learner learns the value of the
optimal policy independently of the agent's actions.

**Twin Delayed Deep Deterministic Algorithm (TD3)**

Before further explaining SAC we are going to provide a quick reminder
about the TD3 algorithm. The idea is that there is some over-estimation
bias in the critic of the DDPG. In TD3 what is happening is that there
are two critics in existence. Each time a value of a critic is needed,
it is considered to be the mean between the two values. And that
prevents over-estimation and empirically it is shown that using two
critics improves much the convergence of the DDPG-style algorithm.
Besides TD3, gives a justification for having a target actor who needs
slow updating of the policy in order to converge. This is related and
parallel to the fact that in TRPO and PPO you should not move too far
from the current policy because you are using a gradient with respect to
that previous policy.

A central feature of SAC is entropy regularisation**.** The policy is
trained to maximize a trade-off between expected return and entropy, a
measure of randomness in the policy. This has a close connection to the
exploration-exploitation trade-off: increasing entropy results in more
exploration, which can accelerate learning later on. It can also prevent
the policy from prematurely converging to a bad local optimum. As
clearly stated by Baris Yazici in
[<span class="underline">\[6\]</span>](\\l): Exploration states how
flexible it is to try new actions, while exploitation is how confident
it is to take a specific action. In most cases, those two concepts are
firmly connected. If we explore enough, we could find newer, better
actions that return more rewards. Still, if we are confident enough
about the action-value estimation, we should stop exploring and start
exploiting the greedy actions.

The version of SAC implemented by OpenAI can only be used for
environments with continuous action spaces. Although an alternate
version of SAC, which slightly changes the policy update rule, can be
implemented to handle discrete action spaces.

####  2.3. Competitive Self-Play

Learning to play a game, the opponent you play against, heavily
influences how well you learn. For instance, always playing against an
amateur player will probably do little to improve yours or the
opponent's game. On the other hand, playing against the world champion
probably also won't help much if they are bringing the A-game. The
question then is: "What's the ideal opponent?”. Thinking of our RL
implementation we could let it train against one that behaves randomly
or one we hard-coded using classical algorithms. The one that behaves
randomly is equal to the amateur and the hard-coded is equal to the
world champion. Both options are not ideal.

For optimal learning, we need something that always matches the skill
level of our agent. The answer is the agent itself. Using this approach
though, we face a few issues. First Overfitting against certain
strategies or play styles. If it's always playing against itself, it
will only learn strategies that work against one particular play style.
Second comes the unstable training. From the perspective of the agent,
the opponent agent is part of the environment as everything else. This
makes learning much more challenging as the environment is always
changing so having some degree of consistency might help. Using
Self-Play we will tackle those problems. 

Let's say that we have two agents of opposing teams playing a symmetric
game***,*** where they share the same policy because they essentially
solve the same problem. Thus each agent shares a copy of that policy. Of
course, as the policy is the behaviour of the agent, it changes over
time as the agents are learning. So the two teams seem to differ as time
passes. Simulating the training and taking a few steps allows the
policies to change. Moving forward in time after reaching a certain step
count we take a snapshot of the policy. We then store that snapshot of a
policy. If the storage is full already we replace the oldest policy with
the new one. We repeat this process each time we reach a multiple of
that step count.

During training, we have our two teams and a collection of policies. One
team of agents is always playing on a fixed policy, meaning it isn't
learning, while the other is learning. The fixed policy is taken from
one of our past snapshots. The chance of picking the latest policy is
defined by a probability that determines it. So either the last model in
our snapshot stack is selected or a random one from the rest in the
stack. That is the opposing behaviour. The change in fixed policy occurs
every certain amount of steps. The idea of snapshotting different
policies is that they may capture different play styles and strategies.
Those play styles may be more cheesy, aggressive, sacrificing, or even
random as well. So by swapping them out from time to time the agent
isn't able to overfit on a specific one. Additionally, it introduces
some consistency the agent can learn. As the fixed policy changes more
frequently than the active one, this leads to more stable training. With
a certain frequency, the teams change, and the other team is learning.
This change occurs each time a certain step count is reached as well.
This is the team change step count. Visual representation: Figure
\[2.4\].

To sum up, in competitive self-play, the agents are split into teams
where one team is learning and adapting and the other team is just
executing past versions of the agent, to make it robust against a large
variety of opponents and provide a more stable learning environment.
This method is has been validated to return optimal results in a small
time period of training.

### 3. Tools & Platforms

#### 3.1. Unity3d Game Engine

#### 

Now that we have covered the theoretical and mathematical background of
the subject we are ready to proceed to the implementation. In order to
achieve the wanted results we first need to set our environment which
technically is our front-end. We are going to use the Unity3d platform,
a free game engine that provides the necessary tools to create the
simulation in three dimensions.

Unity works with ‘Scenes’ like in the movies. Those scenes are made of
objects that resemble items and actors inside of them. In our case, the
concept of the experiments (Scenes) consists of several variants of
opposing humanoid teams who try to reach one or more goals. This calls
for the creation of some objects inside the scene.

First, we need to create a stage as the floor for everything to stand
on. This simple object is made of five rectangular parallelepipeds. Then
the ‘goals’ (or ‘targets’) for our agents to reach are made of spheres
in appearance and a solid cube as a mesh in order not to roll around the
stage. Finally, for the agents we are using is the
[<span class="underline">Space Robot Kyle provided by Unity
Technologies</span>](https://assetstore.unity.com/packages/3d/characters/robots/space-robot-kyle-4696),
which is a free asset provided by Unity3d. We are going to create two
variations, one Red and one Blue. The variants are made by altering the
textures of the original Asset. Every function that allows movement and
interactions is made with code written in C\#. Those script files run
simultaneously in an object-oriented programming way. For the
character’s movement, we use the CharacterController class which
allows us easy access to smooth and realistic movement in every
direction, plus the ability for our agents to jump. To avoid
overfitting, we provide a script to both the agents and the goal(s)
which allows them to change their position randomly (inside the stage’s
boundaries )if the goal is reached or the agent falls off the stage
respectively. This puts randomness to the simulation that is going to
come in handy during training.

In order for the scenes to be visually appealing, proper lighting and
raytracing are applied. The materials used for the objects projected
rays that made the necessary surfaces appear glowing. In the case of the
walls, we are using transparency on the material in order for us to be
able to view from every angle. The camera is rotating around the y-axis
in the center of the stage. A scoreboard is attached to the camera in
order to be visible during the rotation. This scoreboard shows us the
Cumulative Reward, the number of completed episodes, and a step count
from 0 to max steps allowed in each episode. This way we get the full
experience in terms of observation.

The animations used for the Robots are from
[<span class="underline">mixamo</span>](https://www.mixamo.com/#/), are
provided by Adobe, [<span class="underline">\[7\]</span>](\\l). These
animations consist of a running forward, running backwards, jump, and
jump while running model movement. The reason for adding those
animations is only for making the simulation more visually appealing to
the eye, by giving a more realistic humanoid movement set in the agent’s
arsenal.

At this point, the front-end of the simulation is set and we are ready
to proceed to the backend in terms of training and tuning.

![](./media/image31.png)

#### 

#### 3.2. ML-Agents

As stated in [<span class="underline">\[4\]</span>](\\l). Quote: “The
Unity Machine Learning Agents Toolkit (ML-Agents) is an open-source
project that enables games and simulations to serve as environments for
training intelligent agents. It provides implementations (based on
PyTorch) of state-of-the-art algorithms to easily train intelligent
agents for 2D, 3D, and VR/AR games. It is also provided with a
simple-to-use Python API to train Agents using reinforcement learning,
imitation learning, neuroevolution, self-play, or any other methods.
These trained agents can be used for multiple purposes, including
controlling NPC behaviour (in a variety of settings such as multi-agent
and adversarial), automated testing of the game builds, and evaluating
different game design decisions pre-release. The ML-Agents Toolkit is
mutually beneficial for both game developers and AI researchers as it
provides a central platform where advances in AI can be evaluated on
Unity’s rich environments and then made accessible to the wider research
and game developer communities.”

The general structure can be divided in three parts. First of all is the
Learning Environment. Here lies everything correlated with the Unity
Platform from the visuals to the code for the functions as described in
[<span class="underline">\[3.1\]</span>](\\l). Each of our agents that
exist in the environment owns a policy. This policy is the protocol that
determines the behaviour of the agent. In combination with the Academy,
which is the operator that manages the agent training and the
decision-making during runtime, the agents can achieve autonomous
movement and other functions. This is the mechanism that uses the
already trained brains and gives us the results as feedback.

In order to train the brains, we need to access the Neural Network (NN).
The bridge between the Environment and the NN is the Python API. On the
one hand, we have 3d (or in other cases 2d) models that run with C# and
on the other hand, we have a Python Neural Network. The Python API also
contains the RL training algorithms (PPO & SAC). Based on our decision
the NN is trained by the selected algorithm. Following in Figure \[3.5\]
is the connection between the front-end and back-end.

#### 3.3 Google Colab

#### 

Google Colaboratory more commonly referred to as “Google Colab” or just
simply “Colab” is a research project for prototyping machine learning
models on powerful hardware options such as GPUs and TPUs. It provides a
serverless Jupyter notebook environment for interactive development
[<span class="underline">\[8\].</span>](\\l)

As mentioned before, one of our purposes in this
thesis is to guide new researchers into an easy, step-by-step tutorial,
on how to create new reinforcement learning training simulations. The
problem that occurred during the process, is that not everyone owns a
machine that supports such computer power. That’s where Colab comes in
handy, as it allows us to automate

training.

We created a public Colab link for everyone to use
[<span class="underline">\[9\]</span>](\\l). Following is a step by step
tutorial on how to use it for your training.

1\. Create a Unity3d project that uses the ml-agents library. You can
check [<span class="underline">similar work</span>](\\l) here on how to
setup a simple ml-agents project.

2\. Make the project executable. Go to File tab, Go to Build Settings,
Select Target Platform: Linux, Select Architecture: x86\_64 and check
the Server Build box.

3\. Push the created files into a Github repository named after the
simulation.

For example: https://github.com/\<username\>/\<project name\>

4\. Create a folder named mlagents inside a Google Drive. The path
should be /content/gdrive/MyDrive/mlagents/

5\. Fill Google Colab fields with the appropriate parameters such as the
git repository path and the drive path. Finally modify the
hyperparameters section based on the needs of your project. The whole
process is automated and should return the trained policy files (.onnx)
right into the Google drive folder.

### 4\. Implementations & Experiments

At this point, we have covered the theoretical background of the
process, from the general idea of reinforcement learning to the more
specific method of training with self-play. We also have made a
mathematical description of the PPO and SAC algorithms that are going to
use for training. Finally, we have described the tools we are going to
use, Unity3d as the game engine front-end, ml-agents as the machine
learning library, and Google Colab as the computing power needed for the
process.

Now we are ready, to start our two implementations. Those games are
similar at first glance but they differ in some major environment
differences. The main objective in both of our scenes is for our agents
to move to the goal object. We are going to train both scenes with the
PPO and the SAC algorithms and then we are going to compare the results
returned. A hyperparameter tuning is going to be applied as well in
order for our training to tend to become optimised.

Before we start it is necessary to set the hyperparameters for our
trainings in each of our scenes. In order to do so, we need to fill the
Configuration file inside the Google Colab. These hyperparameters
determine the process of the training in great detail.

#### 4.1. Hyper-Parameter Tuning

Following is the list of hyperparameters and a quick description of what
they utilise ( A more detailed description is available in
[<span class="underline">\[4\]</span>](\\l) )

<span class="underline">Training algorithm:</span>

trainer\_type: The type of trainer to use: ppo, sac

<span class="underline">Trainer configurations common to all
trainers:</span>

max\_steps: Total number of steps (i.e., observation collected and
action taken) that must be taken in the environment

time\_horizon: How many steps of experience to collect per-agent before
adding it to the experience buffer.

summary\_freq: Number of experiences that needs to be collected before
generating and displaying training statistics.

keep\_checkpoints: The maximum number of model checkpoints to keep. 

checkpoint\_interval: The number of experiences collected between each
checkpoint by the trainer. 

threaded (boolean): Allow environments to step while updating the model.

<span class="underline">Hyperparameters:</span>

Hyperparameters common to PPO and SAC:

batch\_size: Number of experiences in each iteration of gradient
descent.

buffer\_size: Number of experiences to collect before updating the
policy model. 

learning\_rate: Initial learning rate for gradient descent.

learning\_rate\_schedule: Determines how learning rate changes over
time.

PPO-specific hyperparameters

beta: Strength of the entropy regularization, which makes the policy
"more random."

epsilon: 0.

lambd: Regularization parameter (lambda) used when calculating the
Generalised Advantage Estimate
([GAE](https://arxiv.org/abs/1506.02438)).

num\_epoch: Number of passes to make through the experience buffer when
performing gradient descent optimization.

SAC-specific hyperparameters

buffer\_init\_steps: Number of experiences to collect into the buffer
before updating the policy model. 

init\_entcoef: How much the agent should explore in the beginning of
training.

save\_replay\_buffer:  Whether to save and load the experience replay
buffer as well as the model when quitting and re-starting training. 

tau: How aggressively to update the target network used for
bootstrapping value estimation in SAC.

steps\_per\_update: Average ratio of agent steps (actions) taken to
updates made of the agent's policy.

reward\_signal\_steps\_per\_update: Number of steps per mini batch
sampled and used for updating the reward signals.

<span class="underline">Network\_Settings (common to PPO/SAC):</span>

normalize( boolean ): Whether normalization is applied to the vector
observation inputs.

hidden\_units: Number of units in the hidden layers of the neural
network.

num\_layers: The number of hidden layers in the neural network.

vis\_encode\_type: Encoder type for encoding visual observations.

reward\_signals:

extrinsic:

gamma: Discount factor for future rewards coming from the environment.

strength: Factor by which to multiply the reward given by the
environment.

self\_play:

save\_steps: the frequency we keep a snapshot. 

 team\_change: the frequency we swap the team that is learning.

 swap\_steps: the frequency we change the fixed policy.

 window: the number of snapshots we keep at all times for our fixed
policy.

 play\_against\_latest\_model\_ratio: the probability of selecting the
latest policy or a random policy between the rest in the stack.

Following on Table \[4.1\] are the hyperparameter tuning used for the
both the
experiments:

|                                          |                                       |                                    |              |              |              |              |
| ---------------------------------------- | ------------------------------------- | ---------------------------------- | ------------ | ------------ | ------------ | ------------ |
| Experiment’s Hyperparameter Tuning Table |                                       |                                    |              |              |              |              |
|                                          |                                       |                                    | Game 1 (PPO) | Game 1 (SAC) | Game 2 (PPO) | Game 2 (SAC) |
| trainer\_type                            |                                       |                                    | ppo          | sac          | ppo          | sac          |
| Trainer configurations                   |                                       |                                    |              |              |              |              |
|                                          | max\_steps                            |                                    | 5.000.000    | 5.000.000    | 2.800.000    | 2.800.000    |
|                                          | time\_horizon                         |                                    | 64           | 64           | 128          | 64           |
|                                          | summary\_freq                         |                                    | 10.000       | 10.000       | 20.000       | 20.000       |
|                                          | keep\_checkpoints                     |                                    | 5            | 5            | 5            | 5            |
|                                          | checkpoint\_interval                  |                                    | 100.000      | 100.000      | 400.000      | 400.000      |
|                                          | threaded                              |                                    | false        | false        | false        | false        |
| hyperparameters                          |                                       |                                    |              |              |              |              |
|                                          | Hyperparameters common to PPO and SAC |                                    |              |              |              |              |
|                                          |                                       | batch\_size                        | 512          | 128          | 2048         | 512          |
|                                          |                                       | buffer\_size                       | 2048         | 50000        | 20480        | 50000        |
|                                          |                                       | learning\_rate                     | 0.0003       | 0.0003       | 0.0003       | 0.0003       |
|                                          |                                       | learning\_rate\_schedule           | linear       | constant     | linear       | constant     |
|                                          | PPO-specific hyperparameters          |                                    |              |              |              |              |
|                                          |                                       | beta                               | 5            | \-           | 5            | \-           |
|                                          |                                       | epsilon                            | 0.2          | \-           | 0.2          | \-           |
|                                          |                                       | lambd                              | 0.95         | \-           | 0.95         | \-           |
|                                          |                                       | num\_epoch:                        | 3            | \-           | 3            | \-           |
|                                          | SAC-specific hyperparameters          |                                    |              |              |              |              |
|                                          |                                       | buffer\_init\_steps                | \-           | 1000         | \-           | 0            |
|                                          |                                       | init\_entcoef                      | \-           | 0.5          | \-           | 1.0          |
|                                          |                                       | save\_replay\_buffer               | \-           | false        | \-           | false        |
|                                          |                                       | tau                                | \-           | 0,005        | \-           | 0,005        |
|                                          |                                       | steps\_per\_update                 | \-           | 20.0         | \-           | 20.0         |
|                                          |                                       | reward\_signal\_steps\_per\_update | \-           | 10.0         | \-           | 20.0         |
| network\_settings                        |                                       |                                    |              |              |              |              |
|                                          | normalize                             |                                    | false        | false        | false        | false        |
|                                          | hidden\_units                         |                                    | 128          | 128          | 256          | 256          |
|                                          | num\_layers                           |                                    | 2            | 2            | 2            | 2            |
|                                          | vis\_encode\_type                     |                                    | simple       | simple       | simple       | simple       |
| reward\_signals                          |                                       |                                    |              |              |              |              |
|                                          | extrinsic                             |                                    |              |              |              |              |
|                                          |                                       | gamma                              | 0.99         | 0.99         | 0.99         | 0.99         |
|                                          |                                       | strength                           | 1.0          | 1.0          | 1.0          | 1.0          |
| self\_play                               |                                       |                                    |              |              |              |              |
|                                          | save\_steps                           |                                    | 20.000       | 20.000       | 40.000       | 40.000       |
|                                          | team\_change                          |                                    | 100.000      | 100.000      | 400.000      | 400.000      |
|                                          | swap\_steps                           |                                    | 20.000       | 20.000       | 40.000       | 40.000       |
|                                          | window                                |                                    | 10           | 10           | 10           | 10           |
|                                          | play\_against\_latest\_model\_ratio   |                                    | 0.5          | 0.5          | 0.5          | 0.5          |
|                                          | initial\_elo                          |                                    | 1200.0       | 1200.0       | 1200.0       | 1200.0       |
| Table 4.1 Hyper-parameter tuning table.  |                                       |                                    |              |              |              |              |

#### 4.2. Tensorboard

#### 

While using Google Colab, we are capable of having access to TensorBoard
graphs. Those graphs consist of the following info:

For more details considering the metrics of the graphs are provided in
[<span class="underline">\[4\]</span>](\\l).

Environment Statistics:

Cumulative reward: The mean cumulative episode reward over all agents.
Should increase during a successful training session.

Episode length: The mean length of each episode in the environment for
all agents.

Is Training:

Is Training: A boolean indicating if the agent is updating its model.

Losses:

Policy Loss: (PPO; SAC) - The mean magnitude of policy loss function.
Correlates to how much the policy (process for deciding actions) is
changing. The magnitude of this should decrease during a successful
training session.

Value Loss: (PPO; SAC) - The mean loss of the value function update.
Correlates to how well the model is able to predict the value of each
state. This should increase while the agent is learning, and then
decrease once the reward stabilises.

Q1 loss & Q2 loss: As mentioned before, SAC concurrently learns a
policy \(\pi_{\theta}\) and two
Q-functions \(Q_{\varphi 1},Q_{\varphi 2}\) those two supervise one
another in a way that gives better results.

Policy:

Beta: (Hyperparameter) corresponds to the strength of the entropy
regularization, which makes the policy "more random." This ensures that
agents properly explore the action space during training. Increasing
this will ensure more random actions are taken. This should be adjusted
such that the entropy (measurable from TensorBoard) slowly decreases
alongside increases in reward. If entropy drops too quickly,
increase beta. If entropy drops too slowly, decrease beta.

Entropy: (PPO; SAC) - How random the decisions of the model are. Should
slowly decrease during a successful training process. If it decreases
too quickly, the beta hyperparameter should be increased.

Epsilon: corresponds to the acceptable threshold of divergence between
the old and new policies during gradient descent updating. Setting this
value small will result in more stable updates, but will also slow the
training process.

Extrinsic reward:  (PPO; SAC) - This corresponds to the mean cumulative
reward received from the environment per-episode.

Extrinsic value (estimate): (PPO; SAC) - The mean value estimate for all
states visited by the agent. Should increase during a successful
training session and as the cumulative reward increases. They correspond
to how much future reward the agent predicts itself receiving at any
given point.

Learning rate: (PPO; SAC) - How large a step the training algorithm
takes as it searches for the optimal policy. Should decrease over time.

Continuous/Discrete Entropy Coeff: (SAC) - Determines the relative
importance of the entropy term. This value is adjusted automatically so
that the agent retains some amount of randomness during training.

Self-Play:

ELO: (Self-Play) measures the relative skill level between two players.
In a proper training run, the ELO of the agent should steadily increase.

#### 4.3. Game One: Test Experiment

#### 

For our first implementation, we are training our Agents to conjure up a
behaviour, that allows them to move to a specific goal before the
opponent agent manages to reach it. The environment consists of the
platform, four outer walls, the two opposing agents, and the golden
sphere representing the goal they need to reach. In order for our
training to be faster, we are using nine identical environments at the
same time. Those environments train the same policy and this method
appears to return way faster results.

**Agent Structure:**

The agents in this particular scene/experiment, are structured with the
following characteristics.

Observations: In each step, the agent’s observations (Their knowledge of
the state of the environment) are: 

Their position and rotation in the 3D space. (+6 observations)

The opponent's position. (+3 observations)

The goal's position. (+3 observations)

Ray Perception Sensors. (+10 observations)

Sum: 22 observations total.

Actions: As for the available actions, we are providing our agents with
the following:

Forward and Backward Movement. (Continuous)

Y-Axis Rotation. (Continuous) 

Jump. (Discrete) 

Reward: Lastly, the rewards are assigned as described below: 

In case the agent falls over the platform the reward will be set to -1.

In each step, a penalty (negative reward) equal to normalization times
distanceFromTarget is going to be subtracted. (where normalization =
0.0001)

And in case an agent reaches the goal its reward is going to be set to
+1 and -1 for the opponent, who technically lost.

Each time an agent touches the goal, the goal’s position is changed to a
random one inside the boundaries of the platform. Also in case an agent
falls over the platform, a similar mechanism teleports the entity back
into the game into a random position as well.![](./media/image49.png)

##### 

##### **4.3.1. Training with PPO**

##### 

We are training for about 4.000.000 steps total, using the Proximal
Policy Optimisation Algorithm. During these steps, the training will
exchange between the two teams ( team red and team blue) every 100.000
steps. Also, we’ll keep a new snapshot every 20.000 steps. In the first
1.000.000 rounds, we start with pandemonium. Both agents just keep
running around aimlessly. They also tend to fall off the platform almost
half of the time. Without some proper strategy and some semi-random
movements, there is nothing to see here. Over time, around 2.000.000
steps, the agents seem to reduce the jumping because as an action, it
doesn’t seem to provide any reward for them. This has as an effect the
decrease of the falling off of the platform. After a while, around
3.000.000 steps, the agents tend to reach the target on accident. Those
incidents of course return some positive reward. Thus their luck is the
key for the training at this point because it orientates the policy by a
lot. Finally, around 3.500.000 steps the training got optimised as the
agents started heading straight forward to the goal in order to defeat
their opponent. The training then continues till 4.000.000 steps are
reached, just in case better results occur in the meantime. Indeed
although the agents were reaching the goal with great success, during
the 4.000.000 completion of the training, the agents are starting to
move more accurately and in a straight line. A very interesting concept
is that whenever the agent figured out that the opponent is definitely
going to win, then instead of heading to the target and result in a
certain defeat, he was heading to the center of the platform to wait for
the next goal to appear nearby.

##### **4.3.2. Training with SAC**

##### 

The training process is using the Soft-Actor Critic Algorithm. We are
training for 4.000.000 steps total with the same Self-Play
hyperparameters we used for PPO as well. At first, our agents act
without logic. The action of jumping up and down is getting spammed
continuously without a particular strategy. In the process though and
around 500.000 steps the agents manage to acknowledge the increase of
the reward when moving near the goal. At this point, it is not clear if
the agents use the ray-cast as a tool of exploration yet. During the
steps 1.500.000 to 2.500.000, the results are quite interesting. As it
seems we either have a failure, which means that our agent falls off of
the platform, or success, if and only if the ray-cast locks on the
target. Proceeding around 3.000.000 to 3.500.000 steps the agents now
are not falling off the stage and now they have a competitive behaviour.
It appears that whenever they run next to each other, they tend to push
one another out of the line of victory. This is accomplished due to the
fact that both of them have the knowledge of the opponent's position and
ray-cast tag, as observations. Finally, the training continues till
4.000.000 steps. The agents now are able to reach the target with ease
by scanning the area using their ray-casts. In parallel, the knowledge
of the position of the target attracts them continuously.

##### **4.3.3 Algorithm Comparison**

##### 

The training process for our first implementation is now over. This
experiment is a test in order for us to attain better knowledge on the
hyperparameter tuning. The environment is simple in terms of particles
and complex in terms of the agent’s observations. We provide our agents
with a high quantity of knowledge, with the hope of better return of
results. It is time to compare the lines representing PPO & SAC in the
graphs returned by the [<span class="underline">Tensorboard</span>](\\l)
platform, inside our Google Colab training Lab. The training time for
our final training sessions was around 6-7 hours for PPO and 12-14 hours
for SAC.

As we can observe from Figure\[4.2\] the Cumulative reward graph for
both PPO and SAC follows a similar transition path. At some point, SAC
even surpasses PPO in Mean reward income, but till the end, PPO manages
to get first place. On the other hand, SAC seems to behave a lot better
on the Episode Length graph. This metric is a good measure to determine
when the training has optimised. It felt needed to stop at 4.000.000
steps as we haven’t noticed a worth staying change after that point in
time steps. It is worth noticing that 4.000.000 steps are considered a
large number of steps for an implementation of that scale. That’s why a
further investigation in hyperparameter tuning is necessary.

As of the Losses graphs, those are indicators of successful and
well-going training. Indeed the magnitude of how the policy is changing
is decreasing and the rate of reward prediction, for each state inside
our model, is increasing. Those two prove that both the trainings were
not problematic the whole time.

Policy metrics are also an easy way to tell if our training is
proceeding as wanted. In our case, Entropy & Learning rate are slowly
decreasing during both training processes and the

The extrinsic reward which is the mean cumulative reward received from
the environment per episode is increasing over time. The prediction for
future rewards is the metric called Extrinsic value. This metric works
accurately as well. Finally, Continuous and Discrete Entropy terms
determine the randomness in our simulation. As it seems from the graphs
in both cases ( Con & Dis ) for SAC, those values were adjusting
according to the training state.

The IsTraining graph indicates that both trainings were not interrupted
due to a bug in the environment or even a state where the agent was
trapped and unable to escape with the current set of given actions. This
metric is very useful in alpha versions of a simulation, where the
environment is in a testing phase.

Based on the documentation of ml-agents, [\[4\]](\\l) , quote: “We make
the assumption that the final reward in a trajectory corresponds to the
outcome of an episode. A final reward of +1 indicates winning, -1
indicates losing and 0 indicates a draw. The ELO calculation depends on
this final reward being either +1, 0, -1.” According to the fact that in
this particular game we are using +1 for a win, -1 for a loss, -distance
from the target in each step. We expect a low ELO increase during the
training process. Another factor for the ELO graph is that the training
process was not done at once. It took several sessions in order to
complete each training as it consumes too much computing power. Due to
that fact, the graphs are affected. For instance, in the ELO graph, we
can observe that the line starts from 1200 many times. These are the
times where the training was resumed.

In conclusion, PPO seems to behave slightly better in this particular
experiment as it returns more reward and has a more stable
Increase/Decrease in its graphs. Although both trainings got finally
optimised at around 4.000.000 steps, the result is not satisfying. The
environment can be characterised as simple as it doesn’t include any
particles for the agents to avoid. Also, the twenty-two (22)
observations used seem to make the training more complicated. They
provide the agent with information, but also the knowledge that isn’t
always useful. Another factor that may cause the slow training and the
struggle for results was the Continuous results of the Discrete actions.
What we mean by that is that our actions inside the C\# code are labeled
as continuous, but the product of those actions is a discrete
position/rotation vector for our agents inside the environment (e.g go
left is -1, go right is 1, don’t rotate is 0). This is an issue of how
to handle our hyperparameters as the suggested values differ in each
case. Finally, the neural network hyperparameters consist of 2 hidden
layers with 128 neurons each. Despite the fact that the objective is a
single task to do, the realism of free movement in the mechanics of the
game makes it more complex. Expanding the network may be another useful
change in the hyperparameters because as it seems it will provide deeper
knowledge to our agents. Of course, the case of overfitting is always an
issue, that’s why we apply the random policy whenever an entity is
repositioned inside the environment.

Having in mind this test experiment we will apply the notes we made in
our next one and assume that better results will occur in terms of
training time and mean curriculum reward.

#### 

#### 

#### 

#### 

####   

#### ![](./media/image50.png)

#### 

#### 

#### 

#### 

#### 

#### 

#### 

#### 

#### 

#### 4.4. Game Two: Move to Goal Experiment

The second implementation is an upgrade of the previous one. While we
keep the same concept, the environment is a bit more complex. Like
before, two agents exist on a platform with outer walls. The difference
is that inner walls exist as well, making the search for the goal quite
more tricky. Another change is that instead of one goal, now we have
three, with the hope of more interesting results in terms of optimal
route strategy making.

Although the environment now is more comprehensive, the simulation’s
mechanics follow a more simple structure. For instance, the number of
observations the agents absorb is now 17 in total, as we removed the
knowledge of the opponent’s position, making it more realistic, and the
x-axis/z-axis rotation ( which served no purpose in the training
information ). Also, the addition of inner walls calls for the addition
of a new observable tag for our Ray-casts. Lastly, the reward in each
step is changed to a positive following the formula normalization
divided by the distance from the closest target. This change made the
self-play ELO metric more understandable on Tensorboard. Also, we
increased the weight of normalization from 0.0001 to 0.001. As it
appears it is a practical change for a faster training optimisation.

Modifications have been applied to the actions as well. Now every
possible action represents a Discrete one, making the hyperparameter
tuning lighter in terms of computing power needed ( Batch size/buffer
size ). Of course because of the Unity3d physics in character controller
movements each of those actions has a continuous return of a result
inside the environment. For instance, moving forward won’t just move the
agent 1 square on the front like for example a pawn movement in a chess
game. Instead, the realistic physics movement will apply momentum and
velocity, which will result in a continuous position/rotation.

The training takes place in nine identical platforms training the same
policy as in the previous experiment. Following are the Agent’s
characteristics in a more analytical format.

**Agent Structure:**

The agents in this particular scene/experiment, are structured with the
following characteristics.

Observations: In each step, the agent’s observations (Their knowledge of
the state of the environment) are: 

Their position in the 3D space. (+3 observations)

Their rotation only on the y-axis (+1 observations)

The nearest goal's position. (+3 observations)

Ray Perception Sensors. (+10 observations)

Sum: 17 observations total.

Actions: As for the available actions, we are providing our agents with
the following:

Forward and Backward Movement. (Discrete)

Y-Axis Rotation. (Discrete) 

Jump. (Discrete) 

Reward: Lastly, the rewards are assigned as described below: 

In case the agent falls over the platform the reward will be set to -1.

In each step, a reward (positive) equal to normalization divided by
distanceFromClosestTarget is going to be added. (where normalization =
0.001)

And in case an agent reaches the goal its reward is going to be set to
+1 and -1 for the opponent, who technically
lost.![](./media/image58.png)

##### 

##### **4.4.1 Training with PPO**

Let’s start our training with no other than PPO algorithm. As can be
seen at the [<span class="underline">Hyper-Parameter Tuning</span>](\\l)
matrix we are now training for 2.800.000 steps total. For the first
400.000 steps the agents are jumping around in small radius circles.
This behaviour is due to the spamming of all the possible actions,
rotating all the time running and jumping. Moving forward to the
training process, at 800.000 steps the circles’ radius is larger, but
still, there is nothing to see here. Around 1.200.000 to 1.600.000,
that’s where their curiosity starts to apply and more forward
movements can be observed. In the process and during 2.000.000 steps,
the agents seem to understand that they need to move closer to the goals
but they still lack the knowledge to use the ray-casts properly, that’s
why they keep getting trapped in the edges of the inner walls. A huge
improvement can be seen around 2.400.000 steps where the agents started
patrolling the area by running in large radius circles. Whenever they
identify a goal tag with their ray-casts they move directly to it. Of
course, the results are not optimal and we still have some misses. So
the training continues. Finally, at 2.800.000 steps the behavior is
optimised. The agents manage to capture a high percentage of the goals
they can see. It is worth mentioning that it seems like the agents rely
more on the distance from the nearest target reward at first, but in the
process, they capture the goals they can see with the rays. That is the
reason why they keep running in circles as fast as possible in order to
find the goals more by luck than by the guidance of their position.

##### **4.4.2. Training with SAC**

##### 

We are training using Soft-Actor Critic Algorithm for 2.800.000 steps as
well. At first, we can observe the same behaviours as PPO’s training.
The agents just jump around in small circles in order to acquire the
knowledge of how to move on the platform. As curiosity hits in, the
circles get larger and larger in radius. We’ve already seen similar
behaviours even in the first experiment. Our expectation for the
following results is that in less time than PPO, the agent is going to
structure a more decent behaviour in terms of accuracy. In contrast to
that assumption, the agents are not able to do so. The only change in
their movements, from start to end is how the radius size changes. As a
matter of fact, the only reward the agents tend to gain is by luck and
not by skill. By jumping around all over the platform they manage to
acquire some positive rewards from the goal capture. Using several
combinations of Hyperparameters we managed to realise many flaws in the
structure of SAC in this category of problems and even a bug in the
release of ml-agents version used. Because we are using an arsenal of
discrete actions that return a continuous state in the environment ( new
positions, rotations, etc.) the complexity rises a lot. Thus SAC needs
more intensive training. By analyzing some other examples given by the
Ml-Agents library, those implementations use 10.000.000 to 50.000.000
total for projects of that scale. This proves our assumption that PPO is
more user-friendly when it comes to training of a lower scale model,
that doesn’t require a huge computing power (GPU).

##### **4.4.3. Algorithm Comparison**

Both of our training sessions are now over. The contrast between the two
results is huge. On the one hand, we have PPO with great success in all
areas and on the other, we have SAC without even an optimisation point.
The Hyperparameter tuning for the second algorithm proved to be a
difficult challenge.

There are many techniques that must be followed in order to achieve an
optimal tuning. One of the things a developer has to have in mind when
constructing the configuration file (As explained in
[<span class="underline">4.1 Hyperparameter-Tuning</span>](\\l)), is the
scale of the implementation. That is not always clear at first glance.
For instance, projects that use discrete actions for their agents tend
to be more simple. That’s not always the case though. In some cases,
discrete actions return discrete results. For example in a game of
“connect 4” the player is adding one new mark on the board on his turn
and that has as a result just the addition of the new mark, thus the new
state is created. The problem is that there are times where discrete
actions return continuous results. In our implementation, this is the
case. When the behaviour decides that the agent should go for example
forward a “1” is applied in the code. The result of this discrete action
doesn’t make the agent move just one step forward. Instead, it applies
force to the rigid body of the agent a new continuous position is
applied to the new state of the environment. Another scenario that plays
an important role in the measurement of the scale of the implementation
is the amount of possible action the agent can take. A large number of
possible discrete actions is equal to a lower number of continuous ones
in terms of importance for the tuning.

Ml-agents has a great documentation
[<span class="underline">\[4\]</span>](\\l) where it explains the range
and the available values for each Hyperparameter, based on the situation
of the problem. In our case starting from the default value of each
metric we carefully tuned those values in order to achieve the best
possible results. Another criterion is the parallelism of our
implementation with other projects. More specifically given the
ml-agents examples we managed to observe many similarities with the
WallJump and the Tennis projects. In the first one the agent’s task is
to jump a wall using a box as a median between the jumps it makes. The
way the agent can move and the arsenal of actions in its disposal are
similar to the ones our agents have. The second one deals with the
tennis match of two opposing agents, which is of course a Self-Play
Competitive game. Having in mind those two examples the tuning took
place under similar circumstances.

The following Figures: Figure\[4.5\] & Figure \[4.6\] represent the
graphs for the second experiment. The cumulative reward for SAC was
unstable during the whole process of the training. PPO on the other hand
has a great increase till 2.000.000 steps. The downhill afterward is
easy to explain. As we described in the
[<span class="underline">Self-Play section</span>](\\l), the training of
the agent is versus a fixed older version of itself. At some point the
agent manages to form behaviours that completely destroys the opponent.
But when both the fixed policy and the learning one are on a high level,
there is little room for improvement. Thus this is an indicator for
Self-Play Training optimisation. Another indicator is of course the
Episode Length graph. The absence of any improvement is clear for SAC.
As for PPO, we can see that in only 2.5M steps we have an optimal
behaviour. This is a record in comparison to the previous and more
simple experiment where 4M steps were needed. The losses and policy
sections for SAC just prove that the algorithm was unable to train
properly. All metrics that had to increase instead were decreasing and
vice versa. A great resemblance of healthy training is the “Value Loss
metric” of PPO. This increase proves that the algorithm was able to
predict the reward-based it is going to get before it gets it. In the
policy section of PPO, we have Beta, Entropy, Epsilon, and Learning
rate. Those values were smoothly decreasing giving a reliable result for
our assumptions. The boolean “Is Training” tells us that both trainings
were not interrupted by any error or environment bug. Overall the
Self-Play “ELO” metric is the final result for such a competitive
simulation. SAC never managed to gain ELO points as it never trained
properly. PPO on the other hand had an unstoppable huge increase with
only one final downhill only because the training for those last steps
was stopped and then resumed. Because ELO initializes to 1200 this
downhill is not important.

At this point we got to give it to PPO as it trained such a complex
problem in such a small amount of steps. Thus the Hyperparameter tuning
appears to be a mandatory process before proceeding in any training.

![](./media/image59.png)


### 5\. Epilogue

#### 5.1. Summary and Conclusions

Coming to the end of this dissertation, we can close by analysing some
conclusions we have drawn. As it turns out, reinforcement learning is a
way of learning that can give us amazing results by simulating human
behaviours. Of course what is impressive in the whole process is the way
our agents learned the task, using self-play competitive learning. From
the range of tools we had at our disposal, Unity's contribution together
with the ml-agents library was essential goods for the smooth running of
the work. Of course, we would not be able to achieve even the slightest
education without the computing power of Google, using Google Colab with
the powerful GPUs that it provides to users for free. The automation of
the process by creating our own Colab was another important factor in
the rapid debugging and change in the parameters of our experiments.

To achieve the desired result we used the PPO and SAC algorithms. An
extensive analysis of their mathematical background was preceded, in
order to understand their behaviours during implementation. As it turned
out, specifically for the two experiments we performed, PPO worked much
better. More specifically, in the first experiment, we marginally
preferred PPO, while in the second the SAC completely disappointed us.
It is worth mentioning that the PPO result for the second experiment was
a record training time, especially for an environment of this magnitude.
The reason we achieved such a result was none other than the correct and
clear understanding of the background of the algorithm. So we managed to
implement proper Hyperparameter Tuning, after testing various
conjectures based on the theory.

Closing the conclusion we reached is the importance of understanding the
tools we use from beginning to end. Although there are developers who
are not interested in a deep understanding of the mathematical and
theoretical content of RL and Self-Play but only use the tools from
experience to achieve their goals, we have shown that with these tools
these results are much better.

#### 5.2. Discussion  

In addition to the analysis and comparison of the algorithms, other
notable observations emerged in the practical part of the
implementation. The alternation between the agents during the training
returned impressive results as they formed unexpected behaviours. Many
times, these behaviours gave us evidence of existing errors in the code.
For example, one of the most remarkable moments was one of our initial
implementations. This implementation was an early stage of the first
experiment. So instead of leaving the space around the platform empty,
we mistakenly gave the agents the ability to walk on it. Then when we
checked the results of our training, we noticed that one of the agents
went abroad. So instead of teleporting back inside the platform, instead
he continued to run outside. The result was very interesting as the
other agent who was inside the platform, knowing the position of the
first, lost his mind. Suddenly and while his movements up to that point
returned a good reward, he started moving in a circle as if he did not
know what to do. This proves the strong interdependence between them due
to the observations we gave to the experiment. Then, in the second
experiment, we removed this knowledge and left only the ray-casts.

Another striking observation we made came when we gave a common label to
the exterior and interior walls of the environment. In this case after a
point of training we noticed that the agents stopped approaching the
walls in general. This was because they did not have the ability to
distinguish between them. Thus the negative reward given by a jump over
an outer wall, foreshadowed the agents that all the walls are best
avoided.

In general, as we mentioned in the introduction, when we compared
reinforcement learning with other techniques, we mentioned that its
results may be unexpected. The reason this happens is the huge number of
parameters that affect the whole process. From HyperParameters to the
complexity of the environment itself. These unexpected actions of the
agents give room for improvement but also interest in our
implementations.

#### 5.3. Future Extensions

Regarding the future, we hope that this dissertation will be useful to
develop the field of reinforcement learning. So providing a range of
tools, we expect new developers to extend our examples or even create
their own. Using our notes and Colab, a user friendly environment will
be available on GitHub publicly. More specifically, various ideas that
could be an extension of this thesis are the following:

Wrestling competition between agents.

Capture the Flag

A chase game

In general, any competitive game allows the use of Self-Play even if the
teams are unequal.

Some really useful related work is provided by the youtube channels,
CodeMonkey, Arxiv Insights and Sebastian Schuchmann. Their videos
consist of tutorial for environment making.

### 6\. Bibliography

\[1\] J. Schulman, S. Levine, P. Abbeel, M. Jordan and P. Moritz, Trust
Region Policy Optimization, Proceedings of the 32nd International
Conference on Machine Learning, 2015.

\[2\] J. Schulman, F. Wolski, P. Dhariwal, A. Radford, O. Klimov,
[<span class="underline">Proximal Policy Optimization
Algorithms</span>](https://arxiv.org/abs/1707.06347) , Oracle AI & Data
Science Blog, 2017

\[3\] H.Ji, O.Alfarraj, A. Tolba, [<span class="underline">Artificial
Intelligence-Empowered Edge of Vehicles: Architecture, Enabling
Technologies, and
Applications</span>](https://www.semanticscholar.org/paper/Artificial-Intelligence-Empowered-Edge-of-Vehicles:-Ji-Alfarraj/3b11ba265beca90eb0318d59ab0c695f79142ed2)
, IEEE Access , Vol. PP ,p. 1-1, 2020-03

\[4\] A.Juliani, V.P Berges, E.Teng, A.Cohen, J.Harper, C.Elion, C.Goy,
Y. Gao, H. Henry, M. Mattar, D. Lange, [<span class="underline">Unity: A
General Platform for Intelligent
Agents</span>](https://arxiv.org/abs/1809.02627) ,
[<span class="underline">arXiv:1809.02627</span>](https://arxiv.org/abs/1809.02627),
2020

\[5\] J.Achiam, [<span class="underline">Spinning Up in Deep
Reinforcement
Learning</span>](https://spinningup.openai.com/en/latest/index.html),
2018

\[6\] B.Yazici, [<span class="underline">How to build self-learning
grasping
robot?</span>](https://towardsdatascience.com/sample-efficient-robot-training-on-pybullet-simulation-with-sac-algorithm-71d5d1d4587f),
towards data science, 2020

\[7\] S. Corazza, N. Kareemi, Mixamo, spin-off of Stanford University's
Biomotion Lab, 2008
([<span class="underline">mixamo.com</span>](http://mixamo.com))

\[8\] E. Bisong, [<span class="underline">Google
Colaboratory</span>](https://link.springer.com/chapter/10.1007/978-1-4842-4470-8_7),
Apress: Berkeley, CA, p. 59-64, 2019

\[9\] A. Filios, [<span class="underline">RL Training
Lab</span>](https://colab.research.google.com/drive/1tz04VDRmCNPDrqa2ehtR1Kk9mOmUsFbA?hl=en#scrollTo=wtuV9-yHAoX2),
2021

\[10\] B. Shweta, 5 Things You Need to Know about Reinforcement
Learning, KDNuggets, 2018

\[11\] Reinforcement learning. (21–08-21). In Wikipedia.
[<span class="underline">https://en.wikipedia.org/wiki/Reinforcement\_learning</span>](https://en.wikipedia.org/wiki/Reinforcement_learning)

\[12\] J.Achiam, [<span class="underline">Spinning Up in Deep
Reinforcement
Learning</span>](https://spinningup.openai.com/en/latest/spinningup/rl_intro.html)(RL),
2018

(() => {
    const toggleButton = document.getElementById("chatAssistantToggle");
    const panel = document.getElementById("chatAssistantPanel");
    const closeButton = panel?.querySelector(".chat-panel__close");
    const messagesList = document.getElementById("chatAssistantMessages");
    const form = document.getElementById("chatAssistantForm");
    const textarea = document.getElementById("chatAssistantInput");
    const submitSpinner = form?.querySelector(".spinner-border");

    if (!toggleButton || !panel || !messagesList || !form || !textarea || !submitSpinner) {
        return;
    }

    const state = {
        isOpen: false,
        isSending: false,
        messages: [
            {
                role: "assistant",
                content: "Merhaba! Size nasıl yardımcı olabilirim?"
            }
        ]
    };

    const renderMessages = () => {
        messagesList.innerHTML = "";
        state.messages.forEach(({ role, content }) => {
            const item = document.createElement("li");
            item.className = `chat-message chat-message--${role}`;

            const roleLabel = document.createElement("div");
            roleLabel.className = "chat-message__role text-capitalize";
            roleLabel.textContent = role === "assistant" ? "Asistan" : "Siz";

            const bubble = document.createElement("div");
            bubble.className = "chat-message__bubble";
            bubble.textContent = content;

            item.append(roleLabel, bubble);
            messagesList.appendChild(item);
        });

        messagesList.parentElement?.scrollTo({
            top: messagesList.parentElement.scrollHeight,
            behavior: "smooth"
        });
    };

    const setOpen = (isOpen) => {
        state.isOpen = isOpen;
        panel.classList.toggle("is-open", isOpen);
        toggleButton.setAttribute("aria-expanded", isOpen.toString());

        if (isOpen) {
            textarea.focus();
        }
    };

    const setLoading = (isLoading) => {
        state.isSending = isLoading;
        submitSpinner.classList.toggle("d-none", !isLoading);
        textarea.disabled = isLoading;
        form.querySelector("button[type='submit']").disabled = isLoading;
    };

    const sendMessage = async (content) => {
        const trimmed = content.trim();
        if (!trimmed || state.isSending) return;

        state.messages.push({ role: "user", content: trimmed });
        renderMessages();
        setLoading(true);

        try {
            const response = await fetch("/Ai/Chat", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    messages: state.messages
                })
            });

            if (!response.ok) {
                let errorMessage = "Asistan yanıt verirken bir sorun oluştu.";
                try {
                    const errorJson = await response.json();
                    if (errorJson?.error) {
                        errorMessage = errorJson.error;
                    }
                } catch {
                    // fallback to generic error
                }
                throw new Error(errorMessage);
            }

            const data = await response.json();
            const assistantMessage = data?.reply ?? "Yanıt alınamadı, lütfen tekrar deneyin.";
            state.messages.push({ role: "assistant", content: assistantMessage });
        } catch (error) {
            state.messages.push({
                role: "assistant",
                content: error.message || "Bir hata oluştu, lütfen daha sonra tekrar deneyin."
            });
        } finally {
            renderMessages();
            setLoading(false);
        }
    };

    toggleButton.addEventListener("click", () => {
        setOpen(!state.isOpen);
    });

    closeButton?.addEventListener("click", () => {
        setOpen(false);
    });

    form.addEventListener("submit", (event) => {
        event.preventDefault();
        const message = textarea.value;
        textarea.value = "";
        sendMessage(message);
    });

    renderMessages();
})();